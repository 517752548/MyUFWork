#!/usr/bin/python
# coding:utf-8

import os,sys,time
import zipfile
from hashlib import md5
import shutil
from xml.dom import minidom
oldpack = "/Users/wyn/Downloads/a/u3u2_01281927.apk" #上一个版本
newpack = "/Users/wyn/Downloads/a/u3u2.apk" #新版本

# tmpdir = "/Users/wyn/Downloads/" + time.strftime("%m%M%S")
rootdir = "/Users/wyn/Downloads/tttt"
orootdir = os.path.join(rootdir,"o")
nrootdir = os.path.join(rootdir,"n")
drootdir = os.path.join(rootdir,"d")

alltmpdir=[orootdir,nrootdir,drootdir]
doc = minidom.Document()
doc.appendChild(doc.createComment("this is a simple xml"))
filelist = doc.createElement("arts_md5")
doc.appendChild(filelist)

def createtmpdir():
    if os.path.exists(rootdir):
    	shutil.rmtree(rootdir)
	os.mkdir(rootdir,0777)
	deletetmpdir()
	for t in alltmpdir:
		os.mkdir(t,0777)

       
def createxmlhead():
	# doc = minidom.Document()
	# doc.appendChild(doc.createComment("this is a simple xml"))
	# filelist = doc.createElement("filelist")
	# doc.appendChild(filelist)
	return

def addAssets(assetsname,assetsmd5):
	ass = doc.createElement("file")
	ass.setAttribute("name",assetsname)
	ass.setAttribute("md5",assetsmd5)
	filelist.appendChild(ass)

def createxml():
	f = file(os.path.join(rootdir,"config.xml"),"w")
	doc.writexml(f)
	f.close()

def getmd5(fileb):
	m = md5()
	m.update(fileb)
	return m.hexdigest()

def unzip_file(packname,tmpdir):
	zfobj = zipfile.ZipFile(packname)
	for name in zfobj.namelist():
		if not name.startswith("assets"):
			continue
		if name.startswith("assets/config") or name.startswith("assets/bin") or name.startswith("assets/Scripts"):
			continue
		ext_filename = os.path.join(tmpdir,name)
		ext_dir = os.path.dirname(ext_filename)
		if not os.path.exists(ext_dir):
			os.makedirs(ext_dir,0777)
		outfile = open(ext_filename,'wb')
		t = zfobj.read(name)
		outfile.write(t)
		outfile.close
		# addAssets(name,getmd5(t))

def deletetmpdir():
    for t in alltmpdir:
        if os.path.exists(t):
            shutil.rmtree(t)

def checkfile(parent,filename):
	tnfile = os.path.join(parent,filename)
	tofile = tnfile.replace(nrootdir,orootdir)
	nfile = open(tnfile).read()
	nfilemd5 = getmd5(nfile)
	needcopy = False
	if os.path.exists(tofile):
		tfile = open(tofile).read()
		tfilemd5 = getmd5(tfile)
		if(tfilemd5 != nfilemd5):
			needcopy = True
		# else:
			# print os.path.join(parent,filename)
	else:
		needcopy = True
	if needcopy :
		ndir = parent.replace(nrootdir,drootdir)
		if not os.path.exists(ndir):
			os.makedirs(ndir)
		shutil.copyfile(tnfile,os.path.join(ndir,filename))

def diffpack(ndir,odir):
	if not os.path.exists(ndir):	
		return
	for parent,dirnames,filenames in os.walk(ndir):
		parent1 = parent.replace(ndir,odir)
		for filename in filenames:
			checkfile(parent,filename)

def createzip():
	z = zipfile.ZipFile(os.path.join(drootdir,"../apk_update.zip"),"w")
	for parent,dirnames,filenames in os.walk(drootdir):
		for filename in filenames:
			nfilename = os.path.join(parent,filename).replace(drootdir,"")
			z.write(os.path.join(parent,filename),nfilename)
	z.close()
if __name__ == '__main__':
	createtmpdir()
	createxmlhead()
	unzip_file(oldpack,orootdir)
	unzip_file(newpack,nrootdir)
	diffpack(nrootdir,orootdir)
	createzip()
	createxml()
	# deletetmpdir()




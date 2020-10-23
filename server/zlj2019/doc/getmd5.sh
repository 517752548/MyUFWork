
cd ~/Downloads/a/

cd assets
filelist=`ls`
outfile='a.txt'
rm -fr $outfile
#rm -fr config
for file in $filelist
do 
 
 if [ $file == 'bin' ]
      then
         continue
     fi
	zip -yr $file.zip $file
 	md5sub=`md5 $file.zip|awk '{print $4}'`
 	echo '<file name="'$file'" md5="'$md5sub'"/>' >> $outfile 
done
rm -fr out
mkdir out
mkdir out/arts
mv *.zip out/arts/
mv $outfile out/
mkdir  out/scripts
mv out/arts/Scripts.zip out/scripts/
cd out
scp -r * ts001:/alidata/tmp/

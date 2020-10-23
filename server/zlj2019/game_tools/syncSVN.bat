@ECHO OFF
echo =====svn update u3u2=====
cd /d E:\03project\u3u2
svn up
echo =====svn update documents=====
cd /d E:\03project\documents
svn up
echo =====svn update server=====
cd /d E:\03project\server
svn up
echo =====svn update scripts=====
XCOPY E:\03project\documents\scripts E:\03project\server\trunk\zlj\resources\scripts /m /y
echo =====svn update maps=====
XCOPY E:\03project\documents\maps E:\03project\server\trunk\zlj\resources\maps /m /y
PAUSE
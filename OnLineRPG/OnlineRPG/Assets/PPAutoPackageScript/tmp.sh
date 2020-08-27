#!/bin/bash
is_workspace="true"
project_name=`find . -name *.xcworkspace | awk -F "[/.]" '{print $(NF-1)}'`
if $is_workspace ; then
    xcodebuild -workspace ${project_name}.xcworkspace -scheme $project_name GCC_PREPROCESSOR_DEFINITIONS='$GCC_PREPROCESSOR_DEFINITIONS DEBUG=1 ' archive -archivePath .
else
    xcodebuild -project ${project_name}.xcodeproj -scheme $project_name GCC_PREPROCESSOR_DEFINITIONS='$GCC_PREPROCESSOR_DEFINITIONS DEBUG=1 ' archive -archivePath .
fi
echo 'pwd'
open ../*.xcarchive
sleep 2s
rm -r ../*.xcarchive

open ~/Desktop/sendMessage.app

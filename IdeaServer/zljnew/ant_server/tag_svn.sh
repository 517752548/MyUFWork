#!/bin/bash

trunk_path=$1
tag_path=$2
project=$3
version=$4

svn mkdir $tag_path/$version -m "[project][war][ant_server]mkdir tags $version"
svn delete $tag_path/$version/$project -m "[project][war][ant_server]delete tags $tag_path/$version/$project"
svn cp $trunk_path/trunk/$project $tag_path/$version/$project -m "[project][war][ant_server]$project tags $version"

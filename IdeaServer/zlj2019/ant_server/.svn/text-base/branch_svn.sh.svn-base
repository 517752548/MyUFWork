#!/bin/bash

tag_path=$1
branch_path=$2
project=$3
version=$4
svn mkdir $branch_path/branches/$version -m "[project][war][ant_server]mkdir branches $version"
svn cp $tag_path/tags/$version/$project $branch_path/branches/$version/$project -m "[project][war][ant_server]$project branches $version"

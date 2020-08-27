#!/usr/bin/ruby
# -*- coding: UTF-8 -*-

require 'xcodeproj'

puts '～～～～～～～～～～开始自动修改xcode工程配置～～～～～～～～～～～～～～～～'

project_path = File.join(File.dirname(__FILE__), "../Unity-iPhone.xcodeproj")
project = Xcodeproj::Project.open(project_path)
target = project.targets.first
puts target.name

unityClassGroup = project.main_group.find_subpath(File.join('Classes'), true)
unityClassGroup.set_source_tree('<group>')
unityClassGroup.set_path('Classes')

######################removeBuildPhaseFilesRecursively#############################
def removeBuildPhaseFilesRecursively(aTarget, aGroup)
    aGroup.files.each do |file|
        if file.real_path.to_s.end_with?(".m", ".mm", ".cpp") then
            aTarget.source_build_phase.remove_file_reference(file)
            puts '===========source file===========' + file.real_path.to_s
        elsif !file.real_path.to_s.end_with?(".h")
            aTarget.resources_build_phase.remove_file_reference(file)
            puts '***********resources file***********' + file.real_path.to_s
        end
    end

    aGroup.groups.each do |group|
        removeBuildPhaseFilesRecursively(aTarget, group)
    end
end
####################################################################################

######################################addFilesToGroup###############################
def addFilesToGroup(project, aTarget, aGroup)
    Dir.foreach(aGroup.real_path) do |entry|
        filePath = File.join(aGroup.real_path, entry)

        # 过滤目录和.DS_Store文件
        if !File.directory?(filePath) && entry != ".DS_Store" then

            # 向group中增加文件引用
            fileReference = aGroup.new_reference(filePath)
            # 如果不是头文件则继续增加到Build Phase中，PB文件需要加编译标志
            if filePath.to_s.end_with?("pbobjc.m", "pbobjc.mm") then
                aTarget.add_file_references([fileReference], '-fno-objc-arc')
            elsif filePath.to_s.end_with?(".m", ".mm", ".cpp") then
                aTarget.source_build_phase.add_file_reference(fileReference, true)
                puts '+++++++++++source file+++++++++++' + filePath.to_s.to_s
            elsif !filePath.to_s.end_with?(".h") then
                aTarget.resources_build_phase.add_file_reference(fileReference, true)
                puts '############source file############' + filePath.to_s.to_s
            end

        # 目录情况下, 递归添加
        elsif File.directory?(filePath) && entry != '.' && entry != '..' then
            hierarchy_path = aGroup.hierarchy_path[1, aGroup.hierarchy_path.length]
            subGroup = project.main_group.find_subpath(hierarchy_path + '/' + entry, true)
            subGroup.set_source_tree(aGroup.source_tree)
            subGroup.set_path(aGroup.real_path + entry)
            addFilesToGroup(project, aTarget, subGroup)
        end
    end
end
####################################################################################

if !unityClassGroup.empty? then
    removeBuildPhaseFilesRecursively(target, unityClassGroup)
    unityClassGroup.clear()
end

addFilesToGroup(project, target, unityClassGroup)
project.save

puts '～～～～～～～～～～自动修改xcode工程配置成功～～～～～～～～～～～～～～～～'






@echo off

set LARGE_VER=1.10
set CODE_REV=10738
set LANG_NAME=zh_CN
set LANG_REV=10805
set LANG_SQL_PUB_VER=1.10.10712.cn.1
set JAR_ENC=1
set RES_ENC=1

set ARGS=-DlargeVer=%LARGE_VER% -DcodeRev=%CODE_REV% -DlangName=%LANG_NAME% -DlangRev=%LANG_REV% -DlangSqlPubVer=%LANG_SQL_PUB_VER% -DjarencFlag=%JAR_ENC% -DresencFlag=%RES_ENC%

ant -f autoBuild.ant.xml %ARGS%

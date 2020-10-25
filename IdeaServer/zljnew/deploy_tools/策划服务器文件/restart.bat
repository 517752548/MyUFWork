@echo off

call "D:\scala-2.8.1.final\bin\scala" restart.scala

echo start log_server
cd log_server
call launch.bat
cd..

echo start game_server_1
cd game_server_1
call launch.bat

echo.
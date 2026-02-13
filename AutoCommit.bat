@echo off

set /p msg=Zadej commit message: 

git add .
git commit -m "%msg%"
git push origin main

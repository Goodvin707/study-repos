@echo off
chcp 1251

if "%1"=="" (
    echo Ошибка: Не указан первый параметр
    echo Использование: P5.bat [1^|2^|3] [параметр2] [параметр3]
    echo   1 - Редактор
    echo   2 - Память
    echo   3 - Директория
    exit /b 1
)

if "%1"=="1" goto Editor
if "%1"=="2" goto Memory  
if "%1"=="3" goto Directory

echo Ошибка: Неверный первый параметр
exit /b 1

:Editor
echo Запуск редактора...
edit
exit /b 0

:Memory
if "%2"=="" (
    echo Ошибка: Для режима Память требуется второй параметр
    exit /b 1
)
echo Запуск Mem с ключом %2
mem %2
exit /b 0

:Directory
if "%2"=="" (
    echo Ошибка: Для режима Директория требуется путь к директории
    exit /b 1
)
if "%3"=="" (
    echo Ошибка: Для режима Директория требуется путь для файла
    exit /b 1
)
dir "%2" > "%3\dir_3.txt"
echo Содержимое записано в %3\dir_3.txt
exit /b 0
#pragma once
//------------------------------------------------------
//	Файл:		BMPVIEW.H
//	Описание:	Демонстрирует работу с растрами
//------------------------------------------------------


#define TIMER_ID	1
#define TIMER_RATE	500

LPCWSTR szClassName = L"BMP_Window";
LPCWSTR szAppName = L"BMP Application";

// Обработчики сообщений Windows
BOOL BMP_OnCreate(HWND hwnd, LPCREATESTRUCT lpCreateStruct);
void BMP_OnDestroy(HWND hwnd);
void BMP_OnTimer(HWND hwnd, UINT id);
void BMP_OnKey(HWND hwnd, UINT vk, BOOL fDown, int cRepeat, UINT flags);
void BMP_OnIdle(HWND hwnd);

//Оконная процедура
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

//Вспомогательные функции
BOOL LoadBMP(HDC hdc, LPCWSTR szFileName);
void ShowText(void);
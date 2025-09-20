#include "Randomizer.h"

// –андомизаци€ целого числа в диапазоне
int randInt(int min, int max) { return rand() % (max - min + 1) + min; }

// –андомизаци€ целого четного числа в диапазоне
int randEvenInt(int min, int max) {
	int a = 1;
	while (a % 2 != 0) {
		a = rand() % (max - min + 1) + min;
	}
	return a;
}

// –андомизаци€ дробного числа в диапазоне
double randDouble(int min, int max) { srand(time(0)); return (double)(rand()) / RAND_MAX * (max - min) + min; }
#include <iostream>
#include <string>

//#define DEBUG
#ifndef DEBUG
#define PRINT(i, x)
#else
#define PRINT(i, x) \
	cout << "DEBUG" << ":\t" << "Plus grand palindrome du " << i << "° centre = " << x << endl
#endif

using namespace std;
	
// lMaxPalindrome retourne la longueur du plus grand Palindrome contenu dans s
string lMaxPalindrome(string s){

	int nbCentre = 2*s.length() - 1; // Nombre de centre ( = nombre de caractere + le nombre d'espace entre les caracteres)
	
	int lCurr; // Longueur du plus grand palindrome pour un centre donné
	int debPal, finPal; // Indices du debut et de fin du palindrome pour un centre donne
	
	int lMax = 0; // Longueur du plus grand palindrome
	int debPalMax = 0; // Indice du debut du plus grand palindrome
	
	
	// Parcourt les 'nbCentre' centres 
	for(int i = 0; i < nbCentre; ++i){
		// Si i est impair, le centre courant est un espace situé entre deux caracteres (debPal et finPal, avec finPal = debPal + 1)
		// Si i est pair, le centre courant est le caractere debPal (et on a debPal = finPal)
		debPal = i/2;
		finPal = debPal + i % 2;
		
		// On étend le palindrome autant que possible (tout en le gardant centré au meme endroit)
		//cout << debPal<< " "<<finPal << endl;
		while(debPal >= 0 && finPal < s.length() && s[debPal] == s[finPal]){
			finPal += 1;
			debPal -= 1;
		}
		
		lCurr = finPal - debPal - 1; // Longueur du plus grand palindrome centré au i° centre
		
		if (lCurr > lMax){
			// Ce palindrome est le plus grand rencontré jusqu'a maintenant
			lMax = lCurr;
			debPalMax = debPal + 1;
		}
		PRINT(i, s.substr(debPal + 1, lCurr)); // En mode DEBUG, affiche le plus grand palindrome du centre courant)
	}
	
	/* Idee (non exploitée) pour ameliorer (un tout petit peu) l'algo :
	 * Les plus grands palindromes ont plus de chances de voir le centre se trouver vers le centre de la chaine,
	 * on commence donc a chercher vers le centre pour eviter d'avoir a chercher trop pres des bords
	 */
	 
	return s.substr(debPalMax, lMax);
}

int main(){
	// Tests ...
	cout << lMaxPalindrome("abcababtbatabtcddc") << endl;
}

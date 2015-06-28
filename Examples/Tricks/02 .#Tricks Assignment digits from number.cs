//Vzemane na cifri ot chislo

int chislo = 4320;

int a1 = (chislo / 1000) % 10;
int a2 = (chislo / 100) % 10;
int a3 = (chislo / 10) % 10;
int a4 = (chislo / 1) % 10;


//Second way

char a1 = chislo.ToString()[0];
char a2 = chislo.ToString()[1];
char a3 = chislo.ToString()[2];
char a4 = chislo.ToString()[3];

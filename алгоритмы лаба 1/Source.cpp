#include <iostream>
#include <time.h>
using namespace std;
const int m = 54; //количество элементов 
const int n = 2;  //двузначные числа
const short t = 1.5 * m; //размерность таблицы
double step = 0.0;
double m1 = 54.0;
double t1 = 81.0;

void steps_delete(int table[t], int num)
{
	int k = 0;
	k = (((num * num) % 100) / 10 + (num * num) % 10) % t;

	step--;

	if (table[k] == -1 || table[k] == 0)
	{
		m1--;
	}
	else //если зан€та €чейка таблицы
	{
		int proverka = 0;
		int k1 = 0; int d = 1;
		while (proverka == 0)
		{
			if (d < 50)
			{
				k1 = (k + d * d) % t;

				step--;

				if (table[k1] == -1 || table[k1] == 0)
				{
					proverka = 1;
					m1--;
				}
				d++;
			}
			else if (d == 50)
			{
				k1 = (k + d) % t;

				step--;

				if (table[k1] == -1 || table[k1] == 0)
				{
					proverka = 1;
					m1--;
				}
				d++;
			}
		}
	}
}
int index(int table[t], int num)
{
	int k = 0;
	k = (((num * num) % 100) / 10 + (num * num) % 10) % t;
	if (table[k] == -1 || table[k] == 0)
	{
		k = -1;
		return k;
	}
	else //если зан€та €чейка таблицы
	{
		if (table[k] == num) return k;
		else
		{
			int k1 = 0; int d = 1;
			while (d < 50)
			{
				k1 = (k + d * d) % t;
				if (table[k1] == -1 || table[k1] == 0)
				{
					k1 = -1;
					return k1;
				}
				else if (table[k1] == num) return k1;
				d++;
			}
			while (d >= 50)
			{
				k1 = (k + d) % t;
				if (table[k1] == -1 || table[k1] == 0)
				{
					k1 = -1;
					return k1;
				}
				else if (table[k1] == num) return k1;
				d++;
			}
			
		}
	}
}
int index_findvar(int table[t], int num)
{
	int k = 0;
	k = (((num * num) % 100) / 10 + (num * num) % 10) % t;
	if (table[k] == -1)
	{
		k = -1;
		return k;
	}
	else //если зан€та €чейка таблицы
	{
		if (table[k] == num) return k;
		else
		{
			int k1 = 0; int d = 1;
			while (d < 50)
			{
				k1 = (k + d * d) % t;
				if (table[k1] == -1)
				{
					k1 = -1;
					return k1;
				}
				else if (table[k1] == num) return k1;
				d++;
			}
			while (d >= 50)
			{
				k1 = (k + d) % t;
				if (table[k1] == -1)
				{
					k1 = -1;
					return k1;
				}
				else if (table[k1] == num) return k1;
				d++;
			}

		}
	}
}
void add_to_table(int table[t], int num)
{
	int k = 0;
	k = (((num * num) % 100) / 10 + (num * num) % 10) % t; 

	step++;

	if (table[k] == -1 || table[k] == 0)
	{
		table[k] = num;
		m1++;
	}
	else //если зан€та €чейка таблицы
	{
		int proverka = 0;
		int k1 = 0; int d = 1;
		while (proverka == 0)
		{
			if (d < 50)
			{
				k1 = (k + d * d) % t;

				step++;

				if (table[k1] == -1 || table[k1] == 0)
				{
					table[k1] = num;
					proverka = 1;
					m1++;
				}
				d++;
			}
			else if (d == 50)
			{
				k1 = (k + d) % t;

				step++;

				if (table[k1] == -1 || table[k1] == 0)
				{
					table[k1] = num;
					proverka = 1;
					m1++;
				}
				d++;
			}
		}
	}
}
void Hash(int a[m], int table[t])
{
	for (int i = 0; i < m; i++) //создаем хэш
	{
		int k = 0;
		k = (((a[i] * a[i]) % 100) / 10 + (a[i] * a[i]) % 10) % t; //k = (((a[i]) * a[i]) % 100) % t;  

		step++;

		if (table[k] == -1) table[k] = a[i];
		else //если зан€та €чейка таблицы
		{
			int proverka = 0;
			int k1 = 0; int d = 1;
			while (proverka == 0)
			{
				if (d < 50)
				{
					k1 = (k + d * d) % t;

					step++;

					if (table[k1] == -1)
					{
						table[k1] = a[i];
						proverka = 1;
					}
					d++;
				}
				else if (d == 50)
				{
					k1 = (k + d) % t;

					step++;

					if (table[k1] == -1)
					{
						table[k1] = a[i];
						proverka = 1;
					}
					d++;
				}
			}
		}
	}

	printf("Hash array: \n");
	for (int i = 0; i < t; i++)
	{
		if (i % 8 == 0) printf("\n");
		printf("%d) %d\t\t", i, table[i]);
	}
	printf("\n\n");

	double average_step = step / m1;
	printf("Average number of steps: %lf\n\n", average_step);

	double rate = m1 / t1;
	printf("Occupancy rate: %lf\n\n", rate);
}

void findvar(int table[t], int num)
{
	int k = index_findvar(table, num);
	if (k == -1) printf("The element does not exist.\n\n");
	else printf("The element %d is found. The index of the element = %d.\n\n", num, k);
}
void deletevar(int table[t], int num)
{
	int k = index(table, num);
	if (k == -1) printf("The element does not exist.\n\n");
	else
	{
		printf("The element %d is found. The index of the element = %d.\n", num, k);
		printf("The element %d is deleted.\n\n", num);
		table[k] = 0;
		steps_delete(table, num);
	}
}
void addvar(int table[t], int num)
{
	int k = index(table, num);
	if (k == -1)
	{
		add_to_table(table, num);
		k = index(table, num);
		printf("The index of the element %d = %d.\nThe element added to the table.\n\n", num, k);
	}
	else printf("The element %d is found. The index of the element = %d.\n\n", num, k);
}
void replacevar(int table[t], int num1)
{
	int k = index(table, num1);
	if (k == -1) printf("The element does not exist.\n\n");
	else
	{
		int num2;
		printf("\nChoose the number you want to change this element to:\n1 - random element\n2 - custom element\n");
		scanf_s("%d", &num2);
		switch (num2)
		{
		case 1:
		{
			num2 = rand() % 90 + 10;
			printf("\nCreated random element is %d.\n", num2);

			deletevar(table, num1);

			add_to_table(table, num2);
			int k = index(table, num2);
			printf("The element %d is added. Index of the element %d is %d.\n", num2, num2, k);
			break;
		}
		case 2:
		{
			printf("Enter the number you want to change this element to: ");
			scanf_s("%d", &num2);
			printf("\n");

			deletevar(table, num1);

			add_to_table(table, num2);
			int k = index(table, num2);
			printf("The element %d is added. Index of the element %d is %d.\n", num2, num2, k);
			break;
		}
		default:
		{
			printf("Wrong command number entered. Try again.\n\n");
			break;
		}
		}
	}
}
void coefs()
{
	double average_step = step / m1;
	printf("Average number of steps = %lf\n\n", average_step);
	double rate = m1 / t1;
	printf("Occupancy rate = %lf\n\n", rate);
}

int element_menu()
{
	int num;
	printf("Choose:\n1 - random element\n2 - custom element\n");
	scanf_s("%d", &num);
	switch (num)
	{
	case 1:
	{
		num = rand() % 90 + 10;
		printf("\nCreated random element is %d.\n\n", num);
		return num;
	}
	case 2:
	{
		printf("\nEnter the element: ");
		scanf_s("%d", &num);
		printf("\n");
		return num;
	}
	default:
	{
		printf("\nWrong command number entered. Try again.\n\n");
		return -1;
		break;
	}
	}
}
void print_array(int table[t])
{
	printf("\nArray: \n");
	for (int i = 0; i < t; i++)
	{
		if (i % 8 == 0) printf("\n");
		printf("%d) %d\t\t", i, table[i]);
	}
	printf("\n\n");
}

int main()
{
	srand(time(NULL));

	int a[m]; int el_check = 0; int check_mas[100];
	printf("Array: \n");
	for (int i = 0; i < m; i++)
	{
		el_check = rand() % 90 + 10;
		while (a[i] < 10 || a[i] >99)
		{
			if (check_mas[el_check] == el_check) el_check = rand() % 90 + 10;
			else
			{
				check_mas[el_check] = el_check;
				a[i] = el_check;
				if (i % 8 == 0) printf("\n");
				printf("%d) %d\t\t", i + 1, a[i]);
			}
		}
		
	}
	printf("\n\n");
	int table[t];
	for (int i = 0; i < t; i++) table[i] = -1;

	Hash(a, table);

	int num; int el;
	printf("\nSelect an option:\n1 - Find the element\n2 - Delete the element\n3 - Add a new element\n4 - Replace a new element\n5 - Coefficients\n0 - Exit\n");
	scanf_s("%d", &num);
	printf("\n");
	while (num != 0)
	{
		switch (num)
		{
		case 1:
			el = element_menu();
			if (el == -1) break;
			findvar(table, el);
			print_array(table);
			break;
		case 2:
			el = element_menu();
			if (el == -1) break;
			deletevar(table, el);
			print_array(table);
			break;
		case 3:
			el = element_menu();
			if (el == -1) break;
			addvar(table, el);
			print_array(table);
			break;
		case 4:
			el = element_menu();
			if (el == -1) break;
			replacevar(table, el);
			print_array(table);
			break;
		case 5:
			coefs();
			break;
		default:
			printf("Wrong command number entered. Try again.\n\n");
			break;
		}
		printf("\nSelect an option:\n1 - Find the element\n2 - Delete the element\n3 - Add a new element\n4 - Replace a new element\n5 - Coefficients\n0 - Exit\n");
		scanf_s("%d", &num);
		printf("\n");
	}

	return 0;
}

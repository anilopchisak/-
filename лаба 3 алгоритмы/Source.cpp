#include <iostream>
#include <time.h>
using namespace std;
const int m = 25;

struct Node
{
	int Key;
	Node* Left;
	Node* Right;
};

void addtotree(Node **node, int key)
{
	if ((*node) == NULL) //create the root
	{
		(*node) = new Node; 
		(*node)->Key = key; 
		(*node)->Left = (*node)->Right = NULL;
		return;
	}
	if (key > (*node)->Key) addtotree(&(*node)->Right, key);
	else if (key < (*node)->Key) addtotree(&(*node)->Left, key);
}
void print_tree(Node **node, int lvl)
{
	if (*node != NULL)
	{
		print_tree(&((*node)->Right), lvl + 1);
		for (int i = 0; i <= lvl; i++) printf("     ");
		printf("%d\n", (*node)->Key);
		print_tree(&((*node)->Left), lvl + 1);
	}
}
void RLN(Node **node)
{
	if (*node != NULL)
	{
		RLN(&(*node)->Right);
		RLN(&(*node)->Left);
		printf("%d  ", (*node)->Key);
	}
}

int main()
{
	srand(time(NULL));
	int a[m]; int el_check = 0; int check_mas[1000];
	printf("Array: \n");
	for (int i = 0; i < m; i++)
	{
		el_check = rand() % 1000;
		while (a[i] < 0 || a[i] > 1000)
		{
			if (check_mas[el_check] == el_check) el_check = rand() % 1000;
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

	Node* Tree = NULL;

	for (int i = 0; i < m; i++) addtotree(&Tree, a[i]);

	printf("The tree: \n\n");
	print_tree(&Tree, 0);
	printf("\n\n");

	printf("RLN: \n");
	RLN(&Tree);
	printf("\n\n");

	return 0;
}



//class TreeNode //вершина 
//{
//public:
//	int Key;
//	TreeNode* Left; //ancestors
//	TreeNode* Right;
//	TreeNode(int key) //constructor
//		: Key(key)
//		, Left(nullptr) //ancestors
//		, Right(nullptr)
//	{}
//	/*TreeNode(int keydata)
//		: KeyData(keydata)
//		, Left(0)
//		, Right(0)
//	{
//	}
//	int KeyData;
//	TreeNode* Left;
//	TreeNode* Right;*/
//};
//
//class Tree
//{
//public:
//	TreeNode* Root; //link to the class TreeNode
//	Tree()        //constructor
//		: Root(0)
//	{}
//	~Tree()
//	{
//		DestroyNode(Root);
//	}
//
//private:
//	static void DestroyNode(TreeNode* node) 
//	{
//		if (node) 
//		{
//			DestroyNode(node->Left);
//			DestroyNode(node->Right);
//			delete node;
//		}
//	}
//public:
//	/*void addtotree(TreeNode* current, int key)
//	{
//		while (true)
//		{
//			if (key < Root->Key) current->Left = Root->Left;
//			else if (key > Root->Key) current->Right = Root->Right;
//			return;
//		}
//
//	}*/
//	void addtotree(int key)
//	{
//		Root = Do_addtotree(Root, key);
//	}
//	TreeNode* Do_addtotree(TreeNode* cur_node, int key)
//	{
//		/*TreeNode* current = Root;
//		current = new TreeNode(key);*/
//		if (cur_node == NULL) return new TreeNode(key);
//		if (key < cur_node->Key) cur_node->Left = Do_addtotree(cur_node->Left, key);
//		else if (key > cur_node->Key) cur_node->Right = Do_addtotree(cur_node->Left, key);
//		else return cur_node;
//	}
//
//	
//	/*TreeNode* addtotree(TreeNode* Root, int key)
//	{
//		while (true)
//		{
//			if (key < Root->Key) Root = Root->Left;
//			else if (key > Root->Key) Root = Root->Right;
//			else return;
//		}
//
//	}*/
//	/*Tree()
//		:TData(0)
//	{
//	}
//	
//public:
//	void addtotree(int x)
//	{
//		TreeNode** cur = &TData;
//		while (*cur)
//		{
//			TreeNode& node = **cur;
//			if (x < node.KeyData) cur = &node.Left;
//			else if (x > node.KeyData) cur = &node.Right;
//			else return;
//		}
//		*cur = new TreeNode(x);
//	}
//	void print_tree()
//	{
//		print_tree(t->l, ++u);
//		for (int i = 0; i < u; ++i) cout << "|";
//		cout << t->info << endl;
//		u--;
//	}
//private:
//	TreeNode* TData;*/
//};
//void print_tree(TreeNode* TN, int lvl)
//{
//	if (TN != NULL)
//	{
//		/*if (TN->Right) */
//		print_tree(TN->Right, lvl + 1);
//
//		for (int i = 0; i <= lvl; i++) printf(" ");
//
//		printf("%d\n", TN->Key);
//
//		/*if (TN->Left) */
//		print_tree(TN->Left, lvl + 1);
//	}
//	
//}
//
//
//int main()
//{
//	srand(time(NULL));
//
//	int a[m]; int el_check = 0; int check_mas[100];
//	printf("Array: \n");
//	for (int i = 0; i < m; i++)
//	{
//		el_check = rand() % 90 + 10;
//		while (a[i] < 10 || a[i] >99)
//		{
//			if (check_mas[el_check] == el_check) el_check = rand() % 90 + 10;
//			else
//			{
//				check_mas[el_check] = el_check;
//				a[i] = el_check;
//				if (i % 8 == 0) printf("\n");
//				printf("%d) %d\t\t", i + 1, a[i]);
//			}
//		}
//
//	}
//	printf("\n\n");
//	
//	Tree* T = new Tree(); 
//	TreeNode* TN = new TreeNode(a[0]);
//	T->Root = TN;
//
//	int num = 0;
//	for (int i = 0; i < m; i++) T->addtotree(a[i]);
//	
//	printf("The tree:\n\n");
//	print_tree(TN, 1);
//	return 0;
//}
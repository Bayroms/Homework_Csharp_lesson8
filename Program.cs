Start();

void Start()
{
    while(true)
    {
        Console.ReadLine();
        Console.Clear();

        System.Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
        System.Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
        System.Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
        System.Console.WriteLine("Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
        System.Console.WriteLine("Задача 62: Напишите программу, которая заполнит спирально массив 4 на 4.");
        System.Console.WriteLine("Enter 0 to end");

        int NumTask = int.Parse(Console.ReadLine());
        switch (NumTask)
        {
            case 0: return; break;
            case 54: SortArrayMaxToMin(); break;
            case 56: MinRowInArray(); break;
            case 58: ProductTwoArrays(); break;
            case 60: Array3D(); break;
            case 62: SpiralMatrix(); break;
            default: System.Console.WriteLine("Enter number of task or 0"); break; 
        }
    }
}

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void SortArrayMaxToMin()
{
    int row = SetNumber("Enter number of rows");
    int column = SetNumber("Enter number of colums");
    int[,] matrix = GetRandomMatrix(row, column, 0, 10);
    PrintMatrix(matrix);
    System.Console.WriteLine();
    PrintMatrix(SortMaxtoMin(matrix));

}

int[,] SortMaxtoMin(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(1) - 1; k++)
            {
                if (matrix[i, k] < matrix[i, k + 1])
                {
                    int temp = matrix[i, k + 1];
                    matrix[i, k + 1] = matrix[i, k];
                    matrix[i, k] = temp;
                }
            }
        }
    }
    return matrix;
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void MinRowInArray()
{
    int row = SetNumber("Enter number of rows");
    int column = SetNumber("Enter number of colums");
    int[,] matrix = GetRandomMatrix(row, column, 0, 10);
    PrintMatrix(matrix);
    MinRow(matrix);
}

void MinRow(int[,] matrix)
{
    int minSumLine = 0;
    int sumLine = SumLineElements(matrix, 0);
    for (int i = 1; i < matrix.GetLength(0); i++)
    {
        int tempSumLine = SumLineElements(matrix, i);
        if (sumLine > tempSumLine)
        {
            sumLine = tempSumLine;
            minSumLine = (i + 1);
        }
    }
    Console.WriteLine($"\n{minSumLine} - строкa с наименьшей суммой ({sumLine}) элементов ");
}
int SumLineElements(int[,] matrix, int i)
{
    int sumLine = matrix[i, 0];
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        sumLine += matrix[i, j];
    }
    return sumLine;
}

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

void ProductTwoArrays()
{
    int row = SetNumber("Enter number of rows for first array");
    int column = SetNumber("Enter number of colums for first array");
    int[,] matrixA = GetRandomMatrix(row, column, 0, 10);
    int row2 = SetNumber("Enter number of rows for second array");
    int column2 = SetNumber("Enter number of colums for second array");
    int[,] matrixB = GetRandomMatrix(row2, column2, 0, 10);
    PrintMatrix(matrixA);
    System.Console.WriteLine();
    PrintMatrix(matrixB);
    if (matrixA.GetLength(0) != matrixB.GetLength(0) && matrixA.GetLength(1) != matrixB.GetLength(1))
    {
        System.Console.WriteLine("Enter two arrays with same amount of rows and colums");
    }
    else
    {
        System.Console.WriteLine();
        int[,] matrixC = ProductMatrix(matrixA, matrixB);
        PrintMatrix(matrixC);
    }
}

int[,] ProductMatrix(int[,] matrixA, int[,] matrixB)
{
    int[,] matrixC = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
    for (int i = 0; i < matrixC.GetLength(0); i++)
    {
        for (int j = 0; j < matrixC.GetLength(1); j++)
        {
            matrixC[i, j] = matrixA[i, j] * matrixB[i, j];
        }
    }
    return matrixC;
}
// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void Array3D()
{
    int row = SetNumber("Enter number of rows");
    int column = SetNumber("Enter number of colums");
    int side = SetNumber("Enter number of sides");
    int[,,] matrix3D = FillArray3D(row, column, side);
}

int[,,] FillArray3D(int rows, int colums, int side, int MinValue = 10, int MaxValue = 99)
{
    int[,,] matrix = new int[rows, colums, side];
    var random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < colums; j++)
        {
            for (int k = 0; k < side; k++)
            {
                matrix[i, j, k] = random.Next(MinValue, MaxValue + 1);
                {
                    int element = random.Next(MinValue, MaxValue + 1);
                    if (FindElement(matrix, element)) continue;
                    matrix[i, j, k] = element;
                }
                System.Console.Write($"{matrix[i, j, k]}({i}, {j}, {k}) ");
            }
            System.Console.WriteLine();
        }
    }
    return matrix;
}
bool FindElement(int[,,] array, int el)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == el) return true;
            }
        }
    }
    return false;
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void SpiralMatrix()
{
    int[,] matrix = GetSpiralMatrix();
    PrintMatrix(matrix);
}

int[,] GetSpiralMatrix(int rows = 4, int colums = 4)
{
    int[,] matrix = new int[rows, colums];
    var random = new Random();
    int temp = 1;
    int i = 0;
    int j = 0;
    while (temp <= matrix.GetLength(0) * matrix.GetLength(1))
    {
        matrix[i, j] = temp;
        temp++;
        if (i <= j + 1 && i + j < matrix.GetLength(1) - 1)
            j++;
        else if (i < j && i + j >= matrix.GetLength(0) - 1)
            i++;
        else if (i >= j && i + j > matrix.GetLength(1) - 1)
            j--;
        else
            i--;
    }
    return matrix;
}



int SetNumber(string name)
{
    string[] arr = name.Split(" ");
    System.Console.WriteLine(name);
    int num = int.Parse(Console.ReadLine());
    return num;
}
int[,] GetRandomMatrix(int rows, int colums, int MinValue = -100, int MaxValue = 100)
{
    int[,] matrix = new int[rows, colums];
    var random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < colums; j++)
        {
            matrix[i, j] = random.Next(MinValue, MaxValue + 1);
        }
    }
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + " ");
        }
        System.Console.WriteLine();
    }
}
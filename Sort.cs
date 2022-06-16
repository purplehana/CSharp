using System;
namespace Llll
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 982931, 12133,22,3,5,89,123,12 };
            QuickSort(list,1,4);
            for (int j = 0; j < list.Length; j++)
            {
                Console.WriteLine(list[j]);
            }


        }

        //1.冒泡排序
        private static void BubbleSort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                // 设定一个标记，若为true，则表示此次循环没有进行交换，也就是待排序列已经有序，排序已经完成。
                bool flag = true;

                for (int j = 0; j < list.Length - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int tmp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;

                        flag = false;
                    }
                }



            }

        }


        //2.选择排序
        private static void SelectionSort(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int min_index = i;  //list中最小值的索引
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[min_index])
                    {
                        min_index = j;
                    }
                }
                int temp = list[i];
                list[i] = list[min_index];
                list[min_index] = temp;
            }
        }

        //3.插入排序
        static void InsertSort(int[] dataArray)
        {
            for (int i = 1; i < dataArray.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dataArray[j] > dataArray[i])
                    {
                        int temp = dataArray[j];
                        dataArray[j] = dataArray[i];
                        dataArray[i] = temp;

                    }
                }
            }
        }

        //4.希尔排序
        public static void shellSort(int[] arr)
        {
            int length = arr.Length;
            int temp;
            for (int step = length / 2; step >= 1; step /= 2)
            {
                for (int i = step; i < length; i++)
                {
                    temp = arr[i];
                    int j = i - step;
                    while (j >= 0 && arr[j] > temp)
                    {
                        arr[j + step] = arr[j];
                        j -= step;
                    }
                    arr[j + step] = temp;
                }
            }
        }


        //5.快速排序
        public static void QuickSort(int[] array, int leftindex, int rightindex)
        {
            if (leftindex >= rightindex)
                return;
            int n = leftindex;
            int m = rightindex;
            int pivot = array[leftindex];
            while (n != m)
            {
                for (; n < m; m--)
                {
                    if (array[m] < pivot)
                    {
                        array[n] = array[m];
                        break;
                    }
                }

                for (; n < m; m--)
                {
                    if (array[n] > pivot)
                    {
                        array[m] = array[n];
                        break;
                    }
                }
            }

            array[n] = pivot;
            QuickSort(array, leftindex, n - 1);
            QuickSort(array,n+1,rightindex);

        }

    }   
}
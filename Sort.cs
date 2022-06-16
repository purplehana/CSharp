using System;
namespace Llll
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 9829, 12133,22,3,5,89,123,12 };
            HeapSort(list);
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
        public static int[] SortArray(int[] nums)
        {
            QuickSort(nums, 0, nums.Length - 1);
            return nums;
        }

        public static void QuickSort(int[] array, int begin, int end)
        {
            if (end <= begin) return;
            int pivot = partition(array, begin, end);
            QuickSort(array, begin, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

        private static int partition(int[] array, int begin, int end)
        {
            int pivot = end;//标杆位置
            int counter = begin;//小于pivot的元素的个数
            for (int i = begin; i < end; i++)
            {
                if (array[i] < array[pivot])
                {
                    int temp = array[counter]; array[counter] = array[i]; array[i] = temp;
                    counter++;
                }
            }
            int temp2 = array[pivot]; array[pivot] = array[counter]; array[counter] = temp2;
            return counter;
        }




        //6.归并排序

        public static int[] MergySortArray(int[] nums)
        {
            MergeSort(nums, 0, nums.Length - 1);
            return nums;
        }

        public static  void MergeSort(int[] array, int left, int right)
        {
            if (right <= left) return;
            int mid = (left + right) / 2;//(left+right)/2

            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);

            int[] temp = new int[right - left + 1];//中间数组
            int i = left, j = mid + 1, k = 0;
            while (i <= mid && j <= right)
            {
                temp[k++] = array[i] <= array[j] ? array[i++] : array[j++];
            }
            while (i <= mid) temp[k++] = array[i++];
            while (j <= right) temp[k++] = array[j++];
            for (int p = 0; p < temp.Length; p++)
            {
                array[left + p] = temp[p];
            }
        }


        //7.堆排序
        public static void HeapSort(int[] nums)
        {
            //我们先创建一个大顶堆
            buildMaxHeap(nums);
            //堆顶元素nums[0]为最大元素 ，所以我们将堆顶的元素与数组最后的元素交换
            //调用heapify，对交换后的最顶层元素进行重新的排序
            //但此时我们传入的要调整的数组的长度就减去一位。
            for (int i = nums.Length - 1; i > 0; i--)
            {
                Swap(ref nums[0], ref nums[i]);
                heapify(nums, 0, i);
            }
        }

        /// <summary>
        /// 循环所有的非叶子节点 构建一个大顶堆
        /// </summary>
        /// <param name="nums"></param>
        public static void buildMaxHeap(int[] nums)
        {
            //最大的非叶子节点为nums.Length / 2 - 1，我们从最后一个向前遍历
            for (int i = nums.Length / 2 - 1; i >= 0; i--)
            {
                heapify(nums, i, nums.Length); //调整大顶堆
            }
        }

        /// <summary>
        /// 大顶推的调整 针对根节点以及根节点下所有被改变的节点
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="currentIndex">要调整的根节点位置</param>
        /// <param name="Numslength">要调整的数组的长度</param>
        public static void heapify(int[] nums, int currentIndex, int Numslength)
        {
            //左节点位置
            int left = currentIndex * 2 + 1;
            //右节点位置
            int right = currentIndex * 2 + 2;
            //记录父节点，左子节点，右子节点中最大的节点位置 我们默认先给父节点
            int largePosition = currentIndex;
            //判断左节点和根节点
            if (left < Numslength && nums[left] > nums[largePosition])
            {
                largePosition = left;
            }
            //判断右节点和根节点
            if (right < Numslength && nums[right] > nums[largePosition])
            {
                largePosition = right;
            }
            if (largePosition != currentIndex)
            {
                Swap(ref nums[currentIndex], ref nums[largePosition]);
                //我们是从最后一个父节点向前调整的，当交换数组结构后，有可能会对我们之前已经
                //调整的结构打乱。因此这里加一个递归，此时largePosition位置为被移动的父节点。
                //判断父节点和所有的子节点大小
                heapify(nums, largePosition, Numslength);
            }
        }

        /// <summary>
        /// 交换数组中的两个元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

    }   
}

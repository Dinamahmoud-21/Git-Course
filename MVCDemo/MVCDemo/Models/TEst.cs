namespace MVCDemo.Models
{
    public class TEst
    {
        int _x; //field
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int XX
        {
            get { return X; }
        }
        public void fun1(Parent p)
        {

        }
    }
    public class Parent { }
    public class Child : Parent
    {
        public void main()
        {
            TestSort myTestSort = new TestSort (new BubbleSort());//mian
            TestSort myTestSort2 = new TestSort(new SelectionSort());
            //myTestSort.sort = new BubbleSort();
            //myTestSort.sort = new SelectionSort();
            //myTestSort.sort = new xyz();


        }

    }
    //Data Struct "Sort" - Bubble Sort --Selection  --insertion sort
    //DIP high level class "TestSort" depend on low level class "BubbleSort" 
    //base on abstraction "interface"
    //1- interface 
    //2- high level class base on interfce
    //3- create ask constructore
    public class TestSort
    {
        List<int> list;
        public ISort sort;//depence lossly couple
        public TestSort(ISort Sort)//ask
        {
            sort = Sort;
            //bubbleSort = new InsertionSort();
        }
        public void GetSort()
        {
            sort.Sort();
        }
    }

    public interface ISort
    {
        void Sort();//contract
    }
    public class BubbleSort:ISort
    {
        public void Sort()
        {

        }
    }
    public class SelectionSort:ISort
    {
        public void Sort()
        {

        }
    }
    public class InsertionSort:ISort
    {
        public void Sort()
        {

        }
    }
    public class xyz : ISort
    {
        public void Sort()
        {
           
        }
    }




    public class Company
    {
        Employee emp;
        public Company()
        {
            emp = new Employee();
        }
    }
    public class Trainee
    {

    }

}

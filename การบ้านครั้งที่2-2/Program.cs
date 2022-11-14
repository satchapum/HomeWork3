class Queue<T>
{
    private Node<T> top = null;
    private int length = 0;

    public void Push(T value)
    {
        Node<T> node = new Node<T>(value);
        if(this.top == null)
        {
            this.top = node;
        }
        else
        {
            Node<T> lastNode = this.GetNode(this.length-1);
            lastNode.SetNext(node);
        }
        this.length++;
    }

    public T Pop()
    {
        Node<T> node = this.top;
        this.top = this.top.Next();
        this.length--;
        return node.GetValue();
    }

    public T Get(int index)
    {
        Node<T> ptr = this.GetNode(index);
        return ptr.GetValue();
    }

    public int GetLength()
    {
        return this.length;
    }

    private Node<T> GetNode(int index)
    {
        Node<T> ptr = this.top;
        while(index > 0)
        {
            ptr = ptr.Next();
            index--;
        }
        return ptr;
    }
}
class Node<T>
{
    private T value;
    private Node<T> next = null;

    public Node(T value)
    {
        this.SetValue(value);
    }

    public void SetNext(Node<T> next)
    {
        this.next = next;
    }

    public Node<T> Next()
    {
        return this.next;
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Queue<char> queue = new Queue<char>();
        Queue<char> queue1 = new Queue<char>();
        Queue<char> queue2 = new Queue<char>();
        char input = '.'; 
        int Lcount = 0 , Mcount = 0;
        while(input == '.' || input == 'L' || input == 'M' || input == 'S') {
            Console.Write("Please input size : ");
            input = char.Parse(Console.ReadLine());
            if(input == 'L') {
                queue.Push('1');
                Lcount++;
            }
            else if(input == 'M') {
                queue.Push('2');
                Mcount++;
            }
            else if(input == 'S') {
                queue.Push('3');
            }
        }
        int Mcount1 = 0;
        if(Lcount != 0 || Mcount != 0) {
            for(int queueLength = 0; queueLength <= queue.GetLength()-1; queueLength++) {
                if(queue.Get(queueLength) == '1') {
                    queue1.Push('2');
                    queue1.Push('2');
                    Lcount--;

                }
                else if(queue.Get(queueLength) == '2') {
                    queue1.Push('3');
                    queue1.Push('3');
                    queue1.Push('3');
                    Mcount--;
                    Mcount1++;
                }
            }
        }
        if(Mcount1 != 0) {
            for(int queueLength = 0; queueLength <= queue1.GetLength()-1; queueLength++) {
                if(queue1.Get(queueLength) == '2') {
                    queue2.Push('3');
                    queue2.Push('3');
                    queue2.Push('3');
                    Mcount1--;
                }
            }
        }
        for(int count = 0; count <= queue.GetLength()-1; count++) {
            Console.Write(queue.Get(count));
        }
        for(int count = 0; count <= queue1.GetLength()-1; count++) {
            Console.Write(queue1.Get(count));
        }
        for(int count = 0; count <= queue2.GetLength()-1; count++) {
            Console.Write(queue2.Get(count));
        }        
    }
}
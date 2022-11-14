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
        Queue<string> queue1 = new Queue<string>();
        char input = '.';
        char temp = '0';
        char temp1 = '0'; 
        int GCount = 0; 
        while(input == '.' ||input == 'J' || input == 'G' || input == 'O' || input == 'R') {
            Console.Write("Please input character : ");
            input = char.Parse(Console.ReadLine());
            
            if(temp == '0') {
                if(input != 'R' && (input == '.' ||input == 'J' || input == 'G' || input == 'O' || input == 'R')) {
                    temp = input;
                    queue.Push(input);
                    queue1.Push("");
                }
                else if(input == 'R') {
                    queue1.Push("Invalid pattern");
                }
            }
            else if(input == 'J') {
                if(temp == 'R') {
                    if(temp1 == 'G' || temp1 == 'O'){
                        temp1 = temp;
                        temp = input;
                        queue.Push(input);
                        queue1.Push("");
                    }
                    else {
                        queue1.Push("Invalid pattern");
                    }
                }
                else {
                    temp1 = temp;
                    temp = input;
                    queue.Push(input);
                    queue1.Push("");
                }
            }
            else if(input == 'G') {
                if(GCount > 1) {
                    queue1.Push("Invalid pattern");
                }
                else if(temp == 'R') {
                    if(temp1 == 'J' || temp1 == 'O'){
                        temp1 = temp;
                        temp = input;
                        queue.Push(input);
                        queue1.Push("");
                    }
                    else {
                        queue1.Push("Invalid pattern");
                    }
                }
                else if((temp == 'J' || temp == 'O')) {
                    if(GCount <= 1) {
                        temp1 = temp;
                        temp = input;
                        queue.Push(input);
                        queue1.Push("");
                    }
                    else {
                        queue1.Push("Invalid pattern");
                    }
                }
                else if(temp == 'G') {
                    if(GCount <= 1) {
                        temp1 = temp;
                        temp = input;
                        queue.Push(input);
                        queue1.Push("");
                        GCount++;
                    }
                    else {
                        queue1.Push("Invalid pattern");
                    }
                }
                
                else {
                    temp1 = temp;
                    temp = input;
                    queue.Push(input);
                    queue1.Push("");
                }
            }
            else if(input == 'O') {
                if(temp == 'R') {
                    if(temp1 == 'G' || temp1 == 'J'){
                        temp1 = temp;
                        temp = input;
                        queue.Push(input);
                        queue1.Push("");
                    }
                    else {
                        queue1.Push("Invalid pattern");
                    }
                }
                else {
                    temp1 = temp;
                    temp = input;
                    queue.Push(input);
                    queue1.Push("");
                }
            }
            else if(input == 'R') {
                temp1 = temp;
                temp = input;
                queue.Push(input);
                queue1.Push("");
            }
        }
        if(queue.Get(queue.GetLength()-1) == 'R') {
            if(temp1 == 'J' && queue.Get(0) == 'J') {
                queue.Pop();
                queue1.Pop();
                queue1.Push("Invalid pattern");
            }
            else if(temp1 == 'G' && queue.Get(0) == 'G') {
                queue.Pop();
                queue1.Pop();
                queue1.Push("Invalid pattern");
            }
            else if(temp1 == 'O' && queue.Get(0) == 'O') {
                queue.Pop();
                queue1.Pop();
                queue1.Push("Invalid pattern");
            }
        }
        for(int i = 0; i <= queue1.GetLength()-1;i++) {
            Console.WriteLine(queue1.Get(i));
        }
        for(int i = 0; i <= queue.GetLength()-1;i++) {
            Console.Write(queue.Get(i));
        }    

    }
}


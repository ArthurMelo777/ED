// Classe Pilha implementada com array + classe de testes
using System;

class StackEmpty : Exception {

}

class Stack {
    object[] stack = new object[1];
    int countSize = 0, t = -1, n = 1;

    public void doub () {
        object[] new_stack = new object[n*=2];
        
        for (int i = 0; i < countSize; i++) {
            new_stack[i] = stack[i];
        }

        stack = new_stack;
    }

    public int size () {
        return countSize;
    }

    public bool isEmpty () {
        if (countSize==0) {
            return true;
        }
        return false;
    }

    public void push (object o) {
        if (countSize == n) {
            doub();
        }
        stack[++t] = o;
        countSize++;
    }

    public object pop () {
        if (isEmpty()) {
            throw new StackEmpty();
        }
        countSize--;
        return stack[t--];
    }

    public object top () {
        return stack[t];
    }
}

class Program {
    public static void Main () {
        Stack s = new Stack();

        Console.WriteLine(s.size());
        Console.WriteLine(s.isEmpty());
        s.push(1);
        s.push(2);
        s.push(3);
        Console.WriteLine(s.size());
        Console.WriteLine(s.isEmpty());
        Console.WriteLine(s.pop());
        Console.WriteLine(s.size());
        Console.WriteLine(s.isEmpty());
    }
}
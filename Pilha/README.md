## TAD Pilha
Um **TAD Pilha** é um tipo abstrato de dados que organiza os elementos em formato de uma pilha. Sua organização segue o esquema __LIFO__ (Last in, first out), em que o último elemento a ser inserido é o primeiro a ser retirado. Sua aplicação pode ser vista, por exemplo, em uma pilha de pratos, em que o último prato a ser posto na pilha é o primeiro a ser retirado dela.

### Interface em C#

```
class Stack {
    public int size () {}

    public bool isEmpty () {}

    public void push (object o) {}

    public object pop () {} throw StackEmpty;
    
    public object top () {} throw StackEmpty;
}
```
## TAD Fila
Um **TAD Fila** é um tipo abstrato de dados que organiza os elementos em formato de uma fila. Sua organização segue o esquema __FIFO__ (First in, first out), em que o primeiro elemento a ser inserido é o primeiro a ser retirado. Sua aplicação pode ser vista, por exemplo, em uma fila de pessoas, em que a última pessoa a entrar na fila é a primeira a sair dela.

### Interface em C#

```
class Queue {
    public int size () {}

    public bool isEmpty () {}

    public void enqueue (object o) {}

    public object dequeue () {} throw QueueEmpty;
    
    public object first () {} throw QueueEmpty;
}
```
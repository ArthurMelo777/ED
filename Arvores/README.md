## No Especifico para a Arvore
Classe No:
```
class Node {
    public Node parent () {}
    public IEnumerator children () {}
    public int childrenNumber () {}
    public void addChild (Node o) {}
    public void removeChild (Node o) {}
}
```

## TAD Arvore
Um [TAD Arvore](/Arvores/ArvoreSimples.cs) consiste em nós que possuem relação pai-filho. Uma arvore deve ser visualizada como estando de "cabeça pra baixo", visto que o seu nó "raiz" é o primeiro, os nós seguintes que possuem filho são os nós "galhos" e os que não possuem são os nós "folhas".


Interface do TAD Arvore Simples:
```
class Tree {
    public Node root () {}
    public Node parent (Node v) {}
    public IEnumerator children (Node v) {}
    public bool isInternal (Node v) {}
    public bool isExternal (Node v) {}
    public bool isRoot (Node v) {}
    public void addChild (Node v, object o) {}
    public object remove (Node v) {}
    public void swapElements (Node v, Node w) {}
    public int depth (Node v) {}
    public int height () {}
    public IEnumerator elements () {}
    public IEnumerator nodes () {}
    public int size () {}
    public bool isEmpty () {}
    public object replace (Node v, object o) {}
}
```

### TAD Arvore Binaria de Pesquisa (ABP)

Um [TAD ABP](/Arvores/ArvoreBinariaPesquisa.cs) é uma árvore binária que armazena chaves nos seus nós internos que se relacionam entre si de maneira que ao se pegar um nó qualquer, todos os seus filhos da esquerda serão menores que ele, enquanto todos os seus filhos da direita serão maiores. Os nós externos não armazeram itens (ou seja, tem o valor null).

```

```
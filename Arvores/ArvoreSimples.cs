using System;
using System.Collections;

class Node {
    private object element;
    private Node p;
    private ArrayList c = new ArrayList();

    public Node (Node p, object e) {
        this.p = p;
        this.element = e;
    }
    public Node parent () {
        return p;
    }
    public IEnumerator children () {
        return c.GetEnumerator();
    }
    public int childrenNumber () {
        return c.Count;
    }
    public void addChild (Node o) {
        c.Add(o);
    }
    public void removeChild (Node o) {
        c.Remove(o);
    }
    public void setElement (object o) {
        element = o;
    }

    public object getElement () {
        return element;
    }

    //public override string ToString() {
    //    return $"{element}";
    //}
}

class Tree {
    private Node r;
    private int countSize;
    ArrayList els;
    ArrayList nds;

    public Tree (object o) { // ok
        r = new Node (null, o);
        countSize = 1;
    }

    public Node root () { // ok
        return r;
    }

    public Node parent (Node v) { // ok
        return v.parent();
    }

    public IEnumerator children (Node v) { // ok
        return v.children();
    }

    public bool isExternal (Node v) { // ok
        if (v.childrenNumber() == 0) {
            return true;
        }
        return false;
    }

    public bool isInternal (Node v) { // ok
        if (isExternal(v)) {
            return false;
        }
        return true;
    }

    public bool isRoot (Node v) { // ok
        if (v == r) {
            return true;
        }
        return false;
    }

    public void addChild (Node v, object o) { // ok
        Node n = new Node(v, o);
        v.addChild(n);
        countSize++;
    }

    public object remove (Node v) { // +/- ok, o elemento filho do removido não se torna filho do pai do removido
        Node p = v.parent();
        if (p != null || isExternal(v)) {
            p.removeChild(v);
        }
        else {
            throw new SystemException();
        }

        object o = v.getElement();
        countSize--;
        return o;
    }

    public void swapElements (Node v, Node w) { // ok
        object aux = v.getElement();
        v.setElement(w.getElement());
        w.setElement(aux);
    }

    public int depth (Node v) { // ok
        int d = depth_rec(v);
        return d;
    }

    private int depth_rec (Node v) { // ok
        if (v == r) {
            return 0;
        }
        else {
            return 1 + depth_rec(v.parent());
        }
    }

    public int height (Node v) { // ok
        if (isExternal(v)) {
            return 0;
        }
        else {
            int h = 0;
            var childrens = children(v);
            while (childrens.MoveNext()) {
                h = Math.Max(h, height((Node) childrens.Current));
            }
            return 1+h;
        }
    }

    public IEnumerator elements () { // ok
        els = new ArrayList();
        orderElements(r);
        return els.GetEnumerator();
    }

    public IEnumerator nodes () {
        nds = new ArrayList();
        orderNodes(r);
        return nds.GetEnumerator();
    }
    public int size () { // ok
        return countSize;
    }
    public bool isEmpty () {
        if (root() == null) {
            return true;
        }
        return false;
    }
    public object replace (Node v, object o) {
        object e = v.getElement();
        v.setElement(o);
        return e;
    }
    private void orderElements (Node v) { // preOrder - ok
        els.Add(v.getElement());
        var childrens = children(v);
        while (childrens.MoveNext()) {
            orderElements((Node) childrens.Current);
        }
    }

    private void orderNodes (Node v) { // preOrder
        nds.Add(v);
        var childrens = children(v);
        while (childrens.MoveNext()) {
            orderNodes((Node) childrens.Current);
        }
    }
}

class Program {
    public static void Main () {
        
        Tree t = new Tree(1);

        // TESTE 1 - Pegar root
        Node root = t.root();
        //Console.WriteLine(root);

        // TESTE 2 - Add filho
        t.addChild(t.root(), 2);
        t.addChild(t.root(), 3);
        var enumerator = t.root().children();
        Node aux = t.root();
        int i = 3;

        while (enumerator.MoveNext()) {
            i++;
            aux = (Node) enumerator.Current;
            t.addChild(aux, i);
        }
        //Console.WriteLine(t.size());

        // TESTE 3 - Testar pai
        //Console.WriteLine(root.parent());

        // TESTE 4 - Filhos
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //    Console.WriteLine(aux.getElement());
        //}

        // TESTE 5 - Interno?
        //enumerator.Reset();
        //Console.WriteLine(t.isInternal(t.root()));
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //    Console.WriteLine(t.isInternal(aux));
        //}

        // TESTE 6 - Externo?
        //enumerator.Reset();
        //Console.WriteLine(t.isExternal(t.root()));
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //    Console.WriteLine(t.isExternal(aux));
        //}

        // TESTE 7 - Raiz?
        //enumerator.Reset();
        //Console.WriteLine(t.isRoot(t.root()));
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //    Console.WriteLine(t.isRoot(aux));
        //}

        //TESTE 8 - Remover filho
        //t.remove(aux);
        //enumerator = t.root().children();
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //    Console.WriteLine(aux.getElement());
        //}
        //Console.WriteLine(t.size());
        
        // TESTE 9 - Trocar elementos
        //t.swapElements(t.root(), aux);
        //enumerator = t.root().children();
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //    Console.WriteLine(aux.getElement());
        //}

        // TESTE 10 - Profundidade
        //Console.WriteLine(t.depth(t.root()));
        //enumerator = t.root().children();
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //}
        //Console.WriteLine(t.depth(aux));
        //enumerator = aux.children();
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //}
        //Console.WriteLine(t.depth(aux));

        // TESTE 11 - Altura
        //Console.WriteLine(t.height(t.root()));
        //enumerator = t.root().children();
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //}
        //Console.WriteLine(t.height(aux));
        //enumerator = aux.children();
        //while (enumerator.MoveNext()) {
        //   aux = (Node) enumerator.Current;
        //}
        //Console.WriteLine(t.height(aux));

        // TESTE 12 - Elementos
        //enumerator = t.elements();
        //while (enumerator.MoveNext()) {
        //    Console.WriteLine(enumerator.Current);
        //}

        // TESTE 13 - Nós
        //enumerator = t.nodes();
        //while (enumerator.MoveNext()) {
        //    aux = (Node) enumerator.Current;
        //    Console.WriteLine(aux.getElement());
        //}

        // TESTE 14 - Tamanho
        //Console.WriteLine(t.size());

        // TESTE 15 - Arvore vazia
        //Console.WriteLine(t.isEmpty());

        // TESTE 16 - Substituir elemento
        //t.replace(t.root(), 0);
        //enumerator = t.elements();
        //while (enumerator.MoveNext()) {
        //    Console.WriteLine(enumerator.Current);
        //}
    }
}
// ARVORE UTILIZADA PARA TESTE

//          1
//        /   \
//       2     3
//      /       \
//     4         5
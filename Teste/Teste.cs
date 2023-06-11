﻿using System;
using System.Collections;

class Node {
    private object element;
    private Node p;
    private ArrayList c = new ArrayList();

    public Node (Node p, object e) {
        this.p = p;
        this.element = element;
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
}

class Tree {
    private Node r;
    private int countSize;
    ArrayList els = new ArrayList();
    ArrayList nds = new ArrayList();

    public Tree (object o) {
        r = new Node (null, o);
        countSize = 1;
    }

    public Node root () {
        return r;
    }

    public Node parent (Node v) {
        return v.parent();
    }

    public IEnumerator children (Node v) {
        return v.children();
    }

    public bool isInternal (Node v) {
        if (v.childrenNumber() == 0) {
            return true;
        }
        return false;
    }

    public bool isExternal (Node v) {
        if (isInternal(v)) {
            return false;
        }
        return true;
    }

    public bool isRoot (Node v) {
        if (v == r) {
            return true;
        }
        return false;
    }

    public void addChild (Node v, object o) {
        Node n = new Node(v, o);
        v.addChild(v);
        countSize++;
    }

    public object remove (Node v) {
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

    public void swapElements (Node v, Node w) {
        object aux = v.getElement();
        v.setElement(w.getElement());
        w.setElement(aux);
    }

    public int depth (Node v) {
        int d = depth_rec(v);
        return d;
    }

    private int depth_rec (Node v) {
        if (v == r) {
            return 0;
        }
        else {
            return 1 + depth_rec(v.parent());
        }
    }

    public int height (Node v) {
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

    public IEnumerator elements () {
        orderElements(r);
        return els.GetEnumerator();
    }

    public IEnumerator nodes () {
        orderNodes(r);
        return nds.GetEnumerator();
    }
    public int size () {
        return countSize;
    }
    public bool isEmpty () {
        if (root == null) {
            return true;
        }
        return false;
    }
    public object replace (Node v, object o) {
        object e = v.getElement();
        v.setElement(o);
        return e;
    }
    private void orderElements (Node v) { // preOrder
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

        t.addChild(t.root(), 2);

        var enumerator = t.elements();

        while (enumerator.MoveNext()) {
            Console.WriteLine(enumerator.Current);
        }
    }
}
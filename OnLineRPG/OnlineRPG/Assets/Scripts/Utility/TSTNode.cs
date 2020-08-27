public class TSTNode
{
    private Node root;

    private class Node
    {
        public char c;
        public Node mid, left, right;
        public bool isLeaf = false;
    }

    public bool Get(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return false;
        }

        Node x = Get(root, key, 0);
        if (x == null)
        {
            return false;
        }
        return x.isLeaf;
    }

    private Node Get(Node node, string key, int d)
    {
        if (node == null)
        {
            return null;
        }

        char c = key[d];
        if (c < node.c)
        {
            return Get(node.left, key, d);
        }
        else if (c > node.c)
        {
            return Get(node.right, key, d);
        }
        else if (d < key.Length - 1)
        {
            return Get(node.mid, key, d + 1);
        }
        else
        {
            return node;
        }
    }

    public void Put(string key)
    {
        root = Put(root, key, 0);
    }

    private Node Put(Node node, string key, int d)
    {
        char c = key[d];
        if (node == null)
        {
            node = new Node
            {
                c = c
            };
        }
        if (c < node.c)
        {
            node.left = Put(node.left, key, d);
        }
        else if (c > node.c)
        {
            node.right = Put(node.right, key, d);
        }
        else if (d < key.Length - 1)
        {
            node.mid = Put(node.mid, key, d + 1);
        }
        else
        {
            node.isLeaf = true;
        }

        return node;
    }
}
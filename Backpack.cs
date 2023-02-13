namespace backpack
{
    public static class Backpack
    {

        public static int[] RandValue()
        {
            Random random = new Random();
            int[] result = new int[100];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = random.Next(5, 51);
            }

            return result;
        }

        public static bool[] RandParent()
        {
            Random rnd = new Random();
            bool[] parrnet = new bool[100];

            for (int i = 0; i < parrnet.Length; i++)
            {
                int val = rnd.Next(0, 2);
                if (val == 0)
                {
                    parrnet[i] = false;
                }
                else
                {
                    parrnet[i] = true;
                }
            }


            return parrnet;
        }

        public static bool[] MutateParrent(bool[] parrent)
        {
            bool[] child = TransscriptArr(parrent);
            Random rnd = new Random();

            int index = rnd.Next(0, child.Length);
            if (child[index] == false)
            {
                child[index] = true;
            }
            else
            {
                child[index] = false;
            }

            return child;
        }

        public static bool[] ChooseArr(bool[] parrent, bool[] child, int[] value, int BackPack)
        {
            bool[] result = new bool[100];
            int childVal = CountVal(child, value);
            int parrVal = CountVal(parrent, value);


            if (childVal == BackPack || parrVal == BackPack)
            {
                if (childVal == BackPack)
                {
                    result = TransscriptArr(child);
                }
                else
                {
                    result = TransscriptArr(parrent);
                }
            }
            else if (childVal < BackPack && parrVal < BackPack)
            {
                if (childVal > parrVal && childVal < BackPack)
                {
                    result = TransscriptArr(child);
                }
                if (childVal < parrVal && parrVal < BackPack)
                {
                    result = TransscriptArr(parrent);
                }
            }
            else if (childVal > BackPack && parrVal > BackPack)
            {
                if ((childVal - BackPack) < (parrVal - BackPack))
                {
                    result = TransscriptArr(child);
                }
                else
                {
                    result = TransscriptArr(parrent);
                }
            }

            else if (childVal > BackPack || parrVal > BackPack)
            {
                if (childVal < BackPack && parrVal > BackPack)
                {
                    result = TransscriptArr(child);
                }
                else if (childVal > BackPack && parrVal < BackPack)
                {
                    result = TransscriptArr(parrent);
                }
            }


            return result;
        }

        public static int CountVal(bool[] logic, int[] value)
        {
            int result = 0;
            for (int i = 0; i < logic.Length; i++)
            {
                if (logic[i] == true)
                {
                    result += value[i];
                }
            }

            return result;
        }

        public static bool[] TransscriptArr(bool[] logic)
        {
            bool[] result = new bool[logic.Length];

            for (int i = 0; i < logic.Length; i++)
            {
                if (logic[i] == true)
                {
                    result[i] = true;
                }
                else
                {
                    result[i] = false;
                }

            }

            return result;
        }

    }
}
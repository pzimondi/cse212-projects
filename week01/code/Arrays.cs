public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // My approach to solving this:
        // First, I need an array that can hold 'length' numbers
        // Then I'll fill it up by multiplying the base number by 1, then 2, then 3, etc.
        // The trick is that array positions start at 0, but I want the first multiple (not zero times the number)
        // So when I'm at position 0, I multiply by 1. Position 1, multiply by 2. And so on.
        // Just loop through and calculate each multiple, storing it as I go

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Here's how I'm thinking about this rotation problem:
        // Imagine the list is a circular belt - rotating right means some items from the end
        // jump to the beginning. If I rotate {1,2,3,4,5,6,7,8,9} by 3 positions to the right,
        // the last 3 numbers {7,8,9} need to hop over to the front.
        // 
        // My strategy: figure out where to "cut" the list
        // - Everything after the cut goes to the front
        // - Everything before the cut goes to the back
        // For amount=3, I cut at position 6 (that's 9-3), giving me {1,2,3,4,5,6} and {7,8,9}
        // Then reassemble: {7,8,9} + {1,2,3,4,5,6}

        int cutPosition = data.Count - amount;

        // Grab the tail end that's rotating to the front
        List<int> movingToFront = data.GetRange(cutPosition, amount);

        // Grab everything else that stays but shifts back
        List<int> stayingBehind = data.GetRange(0, cutPosition);

        // Reconstruct the list in its new rotated order
        data.Clear();
        data.AddRange(movingToFront);
        data.AddRange(stayingBehind);
    }
}
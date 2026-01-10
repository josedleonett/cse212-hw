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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // PLAN:
        // 1. Create an array with size 'length' to store the multiples
        // 2. Use a loop that iterates from 1 to 'length' (inclusive)
        // 3. For each iteration i, calculate the multiple: number * i
        // 4. Store the calculated multiple in the array at index (i-1)
        // 5. Return the array containing all the multiples
        
        // IMPLEMENTATION:
        double[] multiples = new double[length];
        for (int i = 1; i <= length; i++)
        {
            multiples[i - 1] = number * i;
        }
        return multiples;
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // PLAN:
        // 1. Normalize the amount to handle cases where amount >= data.Count
        //    Use modulo (%) to wrap around: amount = amount % data.Count
        // 2. If amount is 0 after normalization, no rotation is needed, return early
        // 3. Calculate the starting index: startIndex = data.Count - amount
        // 4. Get the elements from startIndex to the end using GetRange(startIndex, amount)
        //    These are the elements that will be moved to the front
        // 5. Remove those elements from the original list using RemoveRange(startIndex, amount)
        // 6. Insert the extracted elements at the beginning of the list using InsertRange(0, extracted)
        // 7. The list is now rotated right by the specified amount
        
        // IMPLEMENTATION:
        amount = amount % data.Count;
        
        if (amount == 0)
            return;
        
        int startIndex = data.Count - amount;
        List<int> rotatedElements = data.GetRange(startIndex, amount);
        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, rotatedElements);
    }
}

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size,size];

        int top = 0;
        int bot = size;
        int left = 0;
        int right = size;
        int c = 1;
        while (left < right && top < bot) {
            int i = top;
            int k = left;
            while (k < right) {
                matrix[i,k++] = c++;
            }
            k--;
            i++;
            while (i < bot) {
                matrix[i++,k] = c++;
            }
            i--;
            k--;
            while (k >= left) {
                matrix[i,k--] = c++;
            }
            k++;
            i--;
            while (i > top) {
                matrix[i--,k] = c++;
            }
            i++;
            k--;
            
            top++;
            bot--;
            left++;
            right--;
        }

        return matrix;
    }
}

public static class Rectangles
{
    public static int Count(string[] rows)
    {
        int rect = 0;
        for (int r = 0; r < rows.Length-1; r++) {
            string row = rows[r];
            for (int c = 0; c < row.Length-1; c++) {
                if (row[c] != '+') continue;
                List<int> rightCorner = new List<int>();
                List<int> leftCorner = new List<int>();
                for (int upRight = c+1; upRight < row.Length; upRight++) {
                    if (row[upRight] == '+') rightCorner.Add(upRight);
                    else if (row[upRight] != '-') break;
                }
                for (int botLeft = r+1; botLeft < rows.Length; botLeft++) {
                    if (rows[botLeft][c] == '+') leftCorner.Add(botLeft);
                    else if (rows[botLeft][c] != '|') break;
                }
                foreach (int left in leftCorner) {
                    foreach (int right in rightCorner) {
                        if (rows[left][right] == '+') {
                            bool isRect = true;
                            for (int i = c+1; i < right; i++) {
                                if (rows[left][i] != '+' && rows[left][i] != '-') isRect = false;
                            }
                            for (int i = r+1; i < left; i++) {
                                if (rows[i][right] != '+' && rows[i][right] != '|') isRect = false;
                            }
                            if (isRect) rect++;
                        }
                    }
                }
            }
        }

        return rect;
    }
}
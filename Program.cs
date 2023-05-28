using System.Security.Cryptography;

namespace MinimumCostCutStick
{
	internal class Program
	{
		public class MinimumCostCutStick
		{
			private int[][] dp;
			private int[] cuts;
			private int DFS(int left, int right)
			{
				if (dp[left][right] != -1)
				{
					return dp[left][right];
				}
				if (right - left == 1)
				{
					return 0;
				}
				int answer = int.MaxValue;
				for (int mid = left + 1; mid < right; ++mid)
				{
					int cost = DFS(left, mid) + DFS(mid, right) + cuts[right] - cuts[left];
					answer = Math.Min(answer, cost);
				}
				dp[left][right] = answer == int.MaxValue ? 0 : answer;
				return dp[left][right];
			}
			public int MinCost(int n, int[] cuts)
			{
				int m = cuts.Length;
				this.cuts = new int[m + 2];
				Array.Copy(cuts, 0, this.cuts, 1, m);
				this.cuts[m + 1] = n;
				Array.Sort(this.cuts);
				dp = new int[m + 2][];
				for (int i = 0; i < m + 2; ++i)
				{
					dp[i] = new int[m + 2];
					Array.Fill(dp[i], -1);
				}
				return DFS(0, this.cuts.Length - 1);
			}
		}
		static void Main(string[] args)
		{
			MinimumCostCutStick minimumCostCutStick = new();
            Console.WriteLine(minimumCostCutStick.MinCost(7, new int[] { 1, 3, 4, 5 }));
			Console.WriteLine(minimumCostCutStick.MinCost(9, new int[] { 5, 6, 1, 4, 2 }));
            Console.WriteLine(minimumCostCutStick.MinCost(10000, new int[] { 6816, 8372, 3750, 3661, 9442, 4813, 1507, 1421, 5448, 7405, 2401 }));
        }
	}
}
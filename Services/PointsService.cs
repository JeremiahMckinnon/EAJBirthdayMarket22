namespace BirthdayMarket.Services
{
    public class PointsService
    {
        private const int StartingPoints = 500;
        private int currentPoints;
        private readonly Dictionary<string, int> selections = new Dictionary<string, int>();

        public int CurrentPoints
        {
            get => currentPoints;
            private set
            {
                currentPoints = value;
                OnPointsChanged?.Invoke();
            }
        }

        public int PointsUsed => StartingPoints - CurrentPoints;

        public event Action? OnPointsChanged;

        public PointsService()
        {
            ResetPoints();
        }

        public void SubtractPoints(int points)
        {
            if (points < 0)
                throw new ArgumentException("Points to subtract must be non-negative.");

            CurrentPoints = Math.Max(0, CurrentPoints - points);
        }

        public void AddPoints(int points)
        {
            if (points < 0)
                throw new ArgumentException("Points to add must be non-negative.");

            CurrentPoints = Math.Min(StartingPoints, CurrentPoints + points);
        }

        public void ResetPoints()
        {
            CurrentPoints = StartingPoints;
            selections.Clear();
        }

        public bool HasEnoughPoints(int requiredPoints)
        {
            return CurrentPoints >= requiredPoints;
        }

        public void UpdateSelection(string category, int newPoints)
        {
            // Refund points from previous selection in this category
            if (selections.ContainsKey(category))
            {
                AddPoints(selections[category]);
            }

            // Deduct points for new selection
            if (newPoints > 0)
            {
                SubtractPoints(newPoints);
                selections[category] = newPoints;
            }
            else
            {
                selections.Remove(category);
            }
        }

        public int GetSelectionPoints(string category)
        {
            return selections.ContainsKey(category) ? selections[category] : 0;
        }

        public void RefundCategory(string category)
        {
            if (selections.ContainsKey(category))
            {
                AddPoints(selections[category]);
                selections.Remove(category);
            }
        }

        public Dictionary<string, int> GetAllSelections()
        {
            return new Dictionary<string, int>(selections);
        }
    }
}
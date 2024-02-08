namespace MDP.Data
{
    public class Statements
    {
        public static string getCountry = "SELECT name, code FROM countries WHERE id = @id",
            getDemographics = "SELECT name FROM demographics WHERE id = @id",
            getCategory = "SELECT name FROM categories WHERE id = @id",
            getAgeRating = "SELECT name FROM agerating WHERE id = @id",
            getImageType = "SELECT name FROM imagetypes WHERE id = @id",
            getMedia = "SELECT name FROM medias WHERE id = @id",
            getRole = "SELECT name FROM roles WHERE id = @id";

        public static string getWorkById = "SELECT * FROM works WHERE id = @work", 
            getWorkCategoriesByWorkId = "SELECT name FROM categories WHERE id IN (SELECT category FROM workcategories WHERE work = @work)",
            getWorkOtherNames = "SELECT name FROM workothernames WHERE work = @work",
            getWorkDemographics = "SELECT name FROM demographics WHERE id IN (SELECT demographics FROM workdemographics WHERE work = @work)",
            getAllWorkImages = "SELECT * FROM workimages WHERE work = @work",
            getRecentWorkReviews = "SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC LIMIT @limit";
    }
}

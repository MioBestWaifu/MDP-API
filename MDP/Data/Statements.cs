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
            getWorkMedia = "SELECT name FROM medias WHERE id = (SELECT media FROM works WHERE works.id = @work)",
            getWorkMainParticipantRole = "SELECT name FROM roles WHERE id = (SELECT mainParticipantRole FROM works WHERE works.id = @work)",
            getAllWorkImages = "SELECT * FROM workimages WHERE work = @work",
            getRecentWorkReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC LIMIT @limit)",
            getAllWorkReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC)",
            getWorkAverageRating = "SELECT CAST((SELECT SUM(rating) FROM reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC))/(SELECT COUNT(rating)" +
            " FROM reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC)) AS FLOAT) AS average";

        public static string getPersonById = "SELECT * FROM persons WHERE id = @person",
            getPersonRolesByPersonId = "SELECT name FROM roles WHERE id IN (SELECT role FROM personroles WHERE person = @person)",
            getAllPersonImages = "SELECT * FROM personimages WHERE person = @person",
            getRecentPersonReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC LIMIT @limit)",
            getAllPersonReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC)",
            getPersonAverageRating = "SELECT CAST((SELECT SUM(rating) FROM reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC))/(SELECT COUNT(rating)" +
            " FROM reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC)) AS FLOAT) AS average",
            getPersonCountry = "SELECT name FROM countries WHERE countries.id = (SELECT country FROM persons WHERE persons.id = @person)";

        public static string getCompanyById = "SELECT * FROM companies WHERE id = @company",
            getCompanyRolesByCompanyId = "SELECT name FROM roles WHERE id IN (SELECT role FROM companyroles WHERE company = @company)",
            getAllCompanyImages = "SELECT * FROM companyimages WHERE company = @company",
            getRecentCompanyReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC LIMIT @limit)",
            getAllCompanyReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC)",
            getCompanyAverageRating = "SELECT CAST((SELECT SUM(rating) FROM reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC))/(SELECT COUNT(rating)" +
            " FROM reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC)) AS FLOAT) AS average",
            getCompanyCountry = "SELECT name FROM countries WHERE countries.id = (SELECT country FROM companies WHERE companies.id = @company)";

        public static string getUserById = "SELECT * FROM users WHERE id = @user",
            getAllUserImages = "SELECT * FROM userimages WHERE user = @user",
            getUserInterestsByUserId = "SELECT * FROM interests WHERE id IN (SELECT interest FROM userinterests WHERE user = @user)",
            getUserCountry = "SELECT name FROM countries WHERE countries.id = (SELECT country FROM users WHERE users.id = @user)";

        public static string getInterestById = "SELECT * FROM interests WHERE id = @interest",
            getInterestDemographicsByInterestId = "SELECT name FROM demographics WHERE id IN (SELECT demographic FROM interestdemographics WHERE interest = @interest)";

        public static string getReviewById = "SELECT * FROM reviews WHERE id = @review",
            getReviewUserByReviewId = "SELECT * FROM users WHERE id = (SELECT user FROM reviews WHERE reviews.id = @review)";

        public static string getLinkableParticipantPersons = "SELECT * FROM linkableworkpersons WHERE work = @work",
            getLinkableParticipantCompanies = "SELECT * FROM linkableworkcompanies WHERE work = @work",
            getLinkableCurrentAffiliates = "SELECT * FROM linkablecompanyaffiliations WHERE end IS NULL AND company = @company";
    }
}

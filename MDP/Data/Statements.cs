﻿using MDP.Models;
using MDP.Utils;

namespace MDP.Data
{
    /// <summary>
    /// Essa classe contem as strings para criar comandos SQL. Ela só deve ser usada no <see cref="StatementPreparer"/>
    /// Talvez seja melhor esses textos estarem em um arquivo separado. Talvez isso seja feito eventualmente.
    /// </summary>
    public class Statements
    {
        public static string getCountry = "SELECT name, code FROM countries WHERE id = @id",
            getDemographics = "SELECT id, name FROM demographics WHERE id = @id",
            getCategory = "SELECT id, name FROM categories WHERE id = @id",
            getAgeRating = "SELECT id, name FROM agerating WHERE id = @id",
            getImageType = "SELECT name FROM imagetypes WHERE id = @id",
            getMedia = "SELECT id, name FROM medias WHERE id = @id",
            getRole = "SELECT name FROM roles WHERE id = @id",
            getAllDemographics = "SELECT id, name FROM demographics",
            getAllCategories = "SELECT id, name FROM categories",
            getAllAgeRatings = "SELECT id, name FROM agerating",
            getAllMedia = "SELECT id, name FROM medias";

        public static string getWorkById = "SELECT * FROM works WHERE id = @work", 
            getWorkCategoriesByWorkId = "SELECT id, name FROM categories WHERE id IN (SELECT category FROM workcategories WHERE work = @work)",
            getWorkOtherNames = "SELECT name FROM workothernames WHERE work = @work",
            getWorkDemographics = "SELECT id, name FROM demographics WHERE id IN (SELECT demographics FROM workdemographics WHERE work = @work)",
            getWorkMedia = "SELECT id, name FROM medias WHERE id = (SELECT media FROM works WHERE works.id = @work)",
            getWorkMainParticipantRole = "SELECT name FROM roles WHERE id = (SELECT mainParticipantRole FROM works WHERE works.id = @work)",
            getAllWorkImages = "SELECT * FROM workimages WHERE work = @work",
            getRecentWorkReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC) LIMIT @limit",
            getAllWorkReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC)",
            getWorkAverageRating = "SELECT CAST((SELECT SUM(rating) FROM reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC))/(SELECT COUNT(rating)" +
            " FROM reviews WHERE id IN (SELECT review FROM workreviews WHERE work = @work ORDER BY id DESC)) AS FLOAT) AS average",
            getFirstWorks = "SELECT * FROM works LIMIT 30",
            getUserFavoriteWorks = $"SELECT * FROM works LEFT JOIN (SELECT workimages.work, url as url FROM workimages WHERE type = {(int)ImageTypes.CardImage}) AS imgs " +
            $"ON works.id = imgs.work WHERE works.id IN (SELECT work FROM favoriteworks WHERE user = @user)";

        public static string getPersonById = "SELECT * FROM persons WHERE id = @person",
            getPersonRolesByPersonId = "SELECT name FROM roles WHERE id IN (SELECT role FROM personroles WHERE person = @person)",
            getAllPersonImages = "SELECT * FROM personimages WHERE person = @person",
            getRecentPersonReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC) LIMIT @limit",
            getAllPersonReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC)",
            getPersonAverageRating = "SELECT CAST((SELECT SUM(rating) FROM reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC))/(SELECT COUNT(rating)" +
            " FROM reviews WHERE id IN (SELECT review FROM personreviews WHERE person = @person ORDER BY id DESC)) AS FLOAT) AS average",
            getPersonCountry = "SELECT name FROM countries WHERE countries.id = (SELECT country FROM persons WHERE persons.id = @person)";

        public static string getCompanyById = "SELECT * FROM companies WHERE id = @company",
            getCompanyRolesByCompanyId = "SELECT name FROM roles WHERE id IN (SELECT role FROM companyroles WHERE company = @company)",
            getAllCompanyImages = "SELECT * FROM companyimages WHERE company = @company",
            getRecentCompanyReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC) LIMIT @limit",
            getAllCompanyReviews = "SELECT * from reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC)",
            getCompanyAverageRating = "SELECT CAST((SELECT SUM(rating) FROM reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC))/(SELECT COUNT(rating)" +
            " FROM reviews WHERE id IN (SELECT review FROM companyreviews WHERE company = @company ORDER BY id DESC)) AS FLOAT) AS average",
            getCompanyCountry = "SELECT name FROM countries WHERE countries.id = (SELECT country FROM companies WHERE companies.id = @company)";

        public static string getUserById = "SELECT * FROM users WHERE id = @user",
            getSimpleUserById = "SELECT * FROM simpleusers WHERE id = @user",
            getListOfSimpleUsers = "SELECT * FROM simpleusers WHERE id IN (@users)",
            getAllUserImages = "SELECT * FROM userimages WHERE user = @user",
            getUserMainImage = $"SELECT url FROM userimages WHERE user = @user AND type = {(int)ImageTypes.MainImage}",
            getUserInterestsByUserId = "SELECT * FROM interests WHERE id IN (SELECT interest FROM userinterests WHERE user = @user)",
            getUserCountry = "SELECT name FROM countries WHERE countries.id = (SELECT country FROM users WHERE users.id = @user)";

        public static string getInterestById = "SELECT * FROM interests WHERE id = @interest",
            getInterestDemographicsByInterestId = "SELECT name FROM demographics WHERE id IN (SELECT demographic FROM interestdemographics WHERE interest = @interest)",
            getAllInterestBasedOnUser = "SELECT *,interests.id IN(SELECT interest FROM userinterests WHERE user = @user) as selected FROM interests";

        public static string getReviewById = "SELECT * FROM reviews WHERE id = @review",
            getReviewUserByReviewId = "SELECT * FROM users WHERE id = (SELECT user FROM reviews WHERE reviews.id = @review)";

        public static string getLinkablePersonParticipationsByWork = "SELECT * FROM linkableworkpersons WHERE work = @work",
            getLinkablePersonParticipationsByPerson = "SELECT * FROM linkablepersonworks WHERE person = @person",
            getLinkableCompanyParticipationsByWork = "SELECT * FROM linkableworkcompanies WHERE work = @work",
            getLinkableCompanyParticipationsByCompany = "SELECT * FROM linkablecompanyworks WHERE company = @company",
            getLinkableAffiliationsByCompany = "SELECT * FROM linkablecompanyaffiliations WHERE end IS NULL AND company = @company",
            getLinkableAffiliationsByPerson = "SELECT * FROM linkablepersonaffiliations WHERE end IS NULL AND person = @person",
            getLinkableRecentWorkNews = "SELECT * FROM linkableworknews WHERE work = @work ORDER BY id DESC LIMIT @limit",
            getLinkableRecentGlobalNews = "SELECT * FROM linkableglobalnews ORDER BY id DESC LIMIT @limit";

        public static string searchWorks = $"SELECT * FROM works WHERE shortName LIKE @name OR fullName LIKE @name LIMIT {Constants.MAX_SEARCH_WORKS} OFFSET @offset",
            searchPersons = "SELECT * FROM persons WHERE name LIKE @name",
            searchCompanies = "SELECT * FROM companies WHERE name LIKE @name",
            searchUsers = "SELECT * FROM users WHERE name LIKE @name",
            searchInterests = "SELECT * FROM interests WHERE name LIKE @name",
            searchCountries = "SELECT * FROM countries WHERE name LIKE @name",
            searchDemographics = "SELECT * FROM demographics WHERE name LIKE @name",
            searchCategories = "SELECT * FROM categories WHERE name LIKE @name",
            searchMedias = "SELECT * FROM medias WHERE name LIKE @name",
            searchRoles = "SELECT * FROM roles WHERE name LIKE @name";
    }
}

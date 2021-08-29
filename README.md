# Imagegram

Backend system that let's user -
1. Register as a user.
2. Post image with caption.
3. Post comments on posts.
4. Fetch all posts with last 2 comments.
5. Delete account, post and comment.

# Features implemented -
1. Accounts are authenticated "X-Account-Id:{Guid}"
2. API accepts only .png, .jpg and .bmp
3. Posts are sorted by comments count descending.
4. MemoryCaching implemented for fetching posts.

# Tech stack
1. .NET 5
2. SQL Server

# Steps to run -
1. Change connectionString in AppSettings.json file.
2. Run update-database command in Package Manager Console.

# Future enhancements
1. Unit test cases
2. Images are currently being stored in the database. Should be stored in a shared folder for faster access.

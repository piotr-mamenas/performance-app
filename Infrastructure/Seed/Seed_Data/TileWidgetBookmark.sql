DELETE FROM TileWidgetBookmark;
SET IDENTITY_INSERT TileWidgetBookmark ON;

INSERT INTO TileWidgetBookmark (TileWidgetBookmarkId, UserId, BookmarkName, Url, IsDeleted) VALUES (1, '777f2889-298d-41c5-9a87-d035f042fbb3', 'Google', 'https://www.google.com', 1);

SET IDENTITY_INSERT TileWidgetBookmark OFF;

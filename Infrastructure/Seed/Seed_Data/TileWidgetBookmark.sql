DELETE FROM TileWidgetBookmark;
SET IDENTITY_INSERT TileWidgetBookmark ON;

INSERT INTO TileWidgetBookmark (TileWidgetBookmarkId, BookmarkName, Url, IsDeleted) VALUES (1, 'Google', 'https://www.google.com', 1);

SET IDENTITY_INSERT TileWidgetBookmark OFF;

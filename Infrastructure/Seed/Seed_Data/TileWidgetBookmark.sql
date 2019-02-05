DELETE FROM TileWidgetBookmark;
SET IDENTITY_INSERT TileWidgetBookmark ON;

INSERT INTO TileWidgetBookmark (TileWidgetBookmarkId, Url, IsDeleted) VALUES (1,'https://www.google.com',1);

SET IDENTITY_INSERT TileWidgetBookmark OFF;

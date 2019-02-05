DELETE FROM TileWidget;
SET IDENTITY_INSERT TileWidget ON;

INSERT INTO TileWidget (TileWidgetId, UserId, BookmarkId, IsDeleted, TileName, IconName) VALUES (1,'777f2889-298d-41c5-9a87-d035f042fbb3','https://www.google.com',1,'Google Link','fa fa-4x fa-link');
INSERT INTO TileWidget (TileWidgetId, UserId, BookmarkId, IsDeleted, TileName, IconName) VALUES (2,'777f2889-298d-41c5-9a87-d035f042fbb3','https://www.google.com',1,'My Portfolios','fa fa-4x fa-book');

SET IDENTITY_INSERT TileWidget OFF;

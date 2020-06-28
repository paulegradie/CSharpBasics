
write-host "Installing dependencies..."
Install-Module -Name PSSQLite -RequiredVersion 1.0.3
Install-Module -Name dbatools

write-host "Preparing sql..."
Import-Module PSSQLite
Import-Module dbatools

$DataSource = "./ItemRepository.SQLite/Items.sqlite"
$CreateTableQuery = "
CREATE TABLE Items (
   name VARCHAR(255),
   quality integer,
   sellIn integer,
   type VARCHAR(255),
   id VARCHAR(50)
);"

$InsertQuery = "INSERT INTO Items
(name, quality, sellIn, type, id) VALUES
('+5 Dexterity Vest', 10, 20, 'Depreciate', 0),
('Aged Brie', 2, 0, 'Appreciate', 1),
('Elixir of the Mongoose', 5, 7, 'Depreciate', 2),
('Sulfuras, Hand of Ragnaros', 0, 80, 'Legendary', 3),
('Backstage passes to a TAFKAL80ETC concert', 15, 20, 'Concert', 4),
('Conjured Mana Cake', 3, 6, 'Conjure', 5);"



if (Test-Path $DataSource) {
    write-host "Removing old table..."
    Remove-Item $DataSource
}

write-host "Creating new table {Items}..."
Invoke-SqliteQuery -Query $CreateTableQuery -DataSource $DataSource
Invoke-SqliteQuery -Query $InsertQuery -DataSource $DataSource
write-host "Done!"

# write-host "Showing table contents..."
# Invoke-SqliteQuery -DataSource $DataSource -Query "SELECT * FROM Items"

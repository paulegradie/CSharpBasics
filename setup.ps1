
write-host "Installing dependencies..."
Install-Module -Name PSSQLite -RequiredVersion 1.0.3
Install-Module -Name dbatools

write-host "Preparing sql..."
Import-Module PSSQLite
Import-Module dbatools

$DataSource = "./GildedRose/Items.sqlite"
$CreateTableQuery = "
CREATE TABLE Items (
   name VARCHAR(255),
   quality integer,
   sellIn integer,
   type VARCHAR(255)
);"

$InsertQuery = "INSERT INTO Items
(name, quality, sellIn, type) VALUES
('+5 Dexterity Vest', 10, 20, 'Depreciate'),
('Aged Brie', 2, 0, 'Appreciate'),
('Elixir of the Mongoose', 5, 7, 'Depreciate'),
('Sulfuras, Hand of Ragnaros', 0, 80, 'Legendary'),
('Backstage passes to a TAFKAL80ETC concert', 15, 20, 'Concert'),
('Conjured Mana Cake', 3, 6, 'Conjure');"



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

CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE
  keeps (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    img VARCHAR(1000) NOT NULL,
    views INT NOT NULL DEFAULT 0,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

ALTER TABLE accounts
ADD coverImg VARCHAR(1000) NOT NULL;

SELECT
*
FROM
accounts

CREATE TABLE
vaults (
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  isPrivate BOOLEAN NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE 
);

CREATE TABLE
  vaultKeeps (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    keepId INT NOT NULL,
    vaultId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
    FOREIGN KEY (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

  SELECT
        vaultKeeps.*,
        accounts.*
        FROM vaultKeeps
        JOIN accounts ON accounts.id = vaultKeeps.creatorId
        WHERE vaultId = 61;

         SELECT
        vaultKeeps.*,
        keeps.*
        FROM vaultKeeps
        JOIN keeps ON vaultKeeps.keepId = keeps.id
         WHERE vaultId = 61 ;

      
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.creatorId = '66a01f1b3c6756484d577837';

        DELETE FROM `vaults`;


        SELECT 
        keeps.*,
        COUNT(vaultKeeps.id) AS kept,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        GROUP BY (keeps.id);
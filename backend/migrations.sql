Build started...
Build succeeded.
The Entity Framework tools version '6.0.0' is older than that of the runtime '6.0.1'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
warn: Microsoft.EntityFrameworkCore.Model.Validation[10400]
      Sensitive data logging is enabled. Log entries and exception messages may include sensitive application data; this mode should only be enabled during development.
warn: 18/1/2022 18:56:16.795 CoreEventId.SensitiveDataLoggingEnabledWarning[10400] (Microsoft.EntityFrameworkCore.Infrastructure) 
      Sensitive data logging is enabled. Log entries and exception messages may include sensitive application data; this mode should only be enabled during development.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.1 initialized 'ApplicationDbContext' using provider 'Pomelo.EntityFrameworkCore.MySql:6.0.0' with options: SensitiveDataLoggingEnabled DetailedErrorsEnabled ServerVersion 10.4.17-mariadb using snake-case naming  (culture=)
info: 18/1/2022 18:56:17.073 CoreEventId.ContextInitialized[10403] (Microsoft.EntityFrameworkCore.Infrastructure) 
      Entity Framework Core 6.0.1 initialized 'ApplicationDbContext' using provider 'Pomelo.EntityFrameworkCore.MySql:6.0.0' with options: SensitiveDataLoggingEnabled DetailedErrorsEnabled ServerVersion 10.4.17-mariadb using snake-case naming  (culture=)
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `migration_id` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `product_version` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `pk___ef_migrations_history` PRIMARY KEY (`migration_id`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `AspNetRoles` (
        `id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `normalized_name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `concurrency_stamp` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `pk_asp_net_roles` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `AspNetUsers` (
        `id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `user_name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `normalized_user_name` varchar(256) CHARACTER SET utf8mb4 NULL,
        `email` varchar(256) CHARACTER SET utf8mb4 NULL,
        `normalized_email` varchar(256) CHARACTER SET utf8mb4 NULL,
        `email_confirmed` tinyint(1) NOT NULL,
        `password_hash` longtext CHARACTER SET utf8mb4 NULL,
        `security_stamp` longtext CHARACTER SET utf8mb4 NULL,
        `concurrency_stamp` longtext CHARACTER SET utf8mb4 NULL,
        `phone_number` longtext CHARACTER SET utf8mb4 NULL,
        `phone_number_confirmed` tinyint(1) NOT NULL,
        `two_factor_enabled` tinyint(1) NOT NULL,
        `lockout_end` datetime(6) NULL,
        `lockout_enabled` tinyint(1) NOT NULL,
        `access_failed_count` int NOT NULL,
        CONSTRAINT `pk_asp_net_users` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `clientes` (
        `id` bigint NOT NULL AUTO_INCREMENT,
        `nombre` longtext CHARACTER SET utf8mb4 NULL,
        `fecha_nac` datetime(6) NOT NULL,
        `dni` int NOT NULL,
        `nacionalidad` longtext CHARACTER SET utf8mb4 NULL,
        `genero` int NULL,
        `updated_at` datetime(6) NOT NULL,
        `created_at` datetime(6) NOT NULL,
        `estado` int NOT NULL,
        CONSTRAINT `pk_clientes` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `destinos` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nombre` longtext CHARACTER SET utf8mb4 NULL,
        `latitud` double NOT NULL,
        `longitud` double NOT NULL,
        CONSTRAINT `pk_destinos` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `distribuciones` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nota` varchar(128) CHARACTER SET utf8mb4 NOT NULL,
        `un_piso` tinyint(1) NOT NULL,
        CONSTRAINT `pk_distribuciones` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `pagos` (
        `id` int NOT NULL AUTO_INCREMENT,
        `codigo` longtext CHARACTER SET utf8mb4 NULL,
        `boleto` int NOT NULL,
        `tipo` longtext CHARACTER SET utf8mb4 NULL,
        `titular` longtext CHARACTER SET utf8mb4 NULL,
        `dni` bigint NOT NULL,
        `correo` longtext CHARACTER SET utf8mb4 NULL,
        `tarjeta` longtext CHARACTER SET utf8mb4 NULL,
        `nro_tarjeta` bigint NOT NULL,
        `fecha_vencimiento` datetime(6) NOT NULL,
        `precio` int NOT NULL,
        CONSTRAINT `pk_pagos` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `usuarios` (
        `id` bigint NOT NULL AUTO_INCREMENT,
        `username` longtext CHARACTER SET utf8mb4 NULL,
        `password` longtext CHARACTER SET utf8mb4 NULL,
        `salt` longtext CHARACTER SET utf8mb4 NULL,
        `birth_date` datetime(6) NOT NULL,
        `created_at` datetime(6) NOT NULL,
        `gender` int NOT NULL,
        `tipo` int NOT NULL,
        `user_name` longtext CHARACTER SET utf8mb4 NULL,
        `normalized_user_name` longtext CHARACTER SET utf8mb4 NULL,
        `email` longtext CHARACTER SET utf8mb4 NULL,
        `normalized_email` longtext CHARACTER SET utf8mb4 NULL,
        `email_confirmed` tinyint(1) NOT NULL,
        `password_hash` longtext CHARACTER SET utf8mb4 NULL,
        `security_stamp` longtext CHARACTER SET utf8mb4 NULL,
        `concurrency_stamp` longtext CHARACTER SET utf8mb4 NULL,
        `phone_number` longtext CHARACTER SET utf8mb4 NULL,
        `phone_number_confirmed` tinyint(1) NOT NULL,
        `two_factor_enabled` tinyint(1) NOT NULL,
        `lockout_end` datetime(6) NULL,
        `lockout_enabled` tinyint(1) NOT NULL,
        `access_failed_count` int NOT NULL,
        CONSTRAINT `pk_usuarios` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `viajes` (
        `id` int NOT NULL AUTO_INCREMENT,
        `nombre` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `pk_viajes` PRIMARY KEY (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `AspNetRoleClaims` (
        `id` int NOT NULL AUTO_INCREMENT,
        `role_id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `claim_type` longtext CHARACTER SET utf8mb4 NULL,
        `claim_value` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `pk_asp_net_role_claims` PRIMARY KEY (`id`),
        CONSTRAINT `fk_asp_net_role_claims_asp_net_roles_role_id` FOREIGN KEY (`role_id`) REFERENCES `AspNetRoles` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `AspNetUserClaims` (
        `id` int NOT NULL AUTO_INCREMENT,
        `user_id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `claim_type` longtext CHARACTER SET utf8mb4 NULL,
        `claim_value` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `pk_asp_net_user_claims` PRIMARY KEY (`id`),
        CONSTRAINT `fk_asp_net_user_claims_asp_net_users_user_id` FOREIGN KEY (`user_id`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `AspNetUserLogins` (
        `login_provider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `provider_key` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `provider_display_name` longtext CHARACTER SET utf8mb4 NULL,
        `user_id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `pk_asp_net_user_logins` PRIMARY KEY (`login_provider`, `provider_key`),
        CONSTRAINT `fk_asp_net_user_logins_asp_net_users_user_id` FOREIGN KEY (`user_id`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `AspNetUserRoles` (
        `user_id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `role_id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `pk_asp_net_user_roles` PRIMARY KEY (`user_id`, `role_id`),
        CONSTRAINT `fk_asp_net_user_roles_asp_net_roles_role_id` FOREIGN KEY (`role_id`) REFERENCES `AspNetRoles` (`id`) ON DELETE CASCADE,
        CONSTRAINT `fk_asp_net_user_roles_asp_net_users_user_id` FOREIGN KEY (`user_id`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `AspNetUserTokens` (
        `user_id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `login_provider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `value` longtext CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `pk_asp_net_user_tokens` PRIMARY KEY (`user_id`, `login_provider`, `name`),
        CONSTRAINT `fk_asp_net_user_tokens_asp_net_users_user_id` FOREIGN KEY (`user_id`) REFERENCES `AspNetUsers` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `filas` (
        `id` int NOT NULL AUTO_INCREMENT,
        `distribucion_id` int NULL,
        `distribucion_id1` int NULL,
        CONSTRAINT `pk_filas` PRIMARY KEY (`id`),
        CONSTRAINT `fk_filas_distribuciones_distribucion_id` FOREIGN KEY (`distribucion_id`) REFERENCES `distribuciones` (`id`),
        CONSTRAINT `fk_filas_distribuciones_distribucion_id1` FOREIGN KEY (`distribucion_id1`) REFERENCES `distribuciones` (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `Arista` (
        `id` int NOT NULL AUTO_INCREMENT,
        `origen_id` int NOT NULL,
        `destino_id` int NOT NULL,
        `demora` longtext CHARACTER SET utf8mb4 NOT NULL,
        `precio` double NOT NULL,
        `viaje_id` int NULL,
        CONSTRAINT `pk_arista` PRIMARY KEY (`id`),
        CONSTRAINT `fk_arista_destinos_destino_id` FOREIGN KEY (`destino_id`) REFERENCES `destinos` (`id`) ON DELETE CASCADE,
        CONSTRAINT `fk_arista_destinos_origen_id` FOREIGN KEY (`origen_id`) REFERENCES `destinos` (`id`) ON DELETE CASCADE,
        CONSTRAINT `fk_arista_viajes_viaje_id` FOREIGN KEY (`viaje_id`) REFERENCES `viajes` (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `boletos` (
        `id` int NOT NULL AUTO_INCREMENT,
        `recorrido_id` int NOT NULL,
        `origen_id` int NOT NULL,
        `destino_id` int NOT NULL,
        `pasajero_id` bigint NOT NULL,
        `pago_id` int NULL,
        `asiento` int NOT NULL,
        `precio` longtext CHARACTER SET utf8mb4 NULL,
        `hora_salida` longtext CHARACTER SET utf8mb4 NULL,
        `hora_salida_adicional` longtext CHARACTER SET utf8mb4 NULL,
        `hora_llegada` longtext CHARACTER SET utf8mb4 NULL,
        `estado` longtext CHARACTER SET utf8mb4 NOT NULL,
        `fecha` datetime(6) NOT NULL,
        `fecha_emision` datetime(6) NOT NULL,
        `vendedor_id` bigint NULL,
        CONSTRAINT `pk_boletos` PRIMARY KEY (`id`),
        CONSTRAINT `fk_boletos_clientes_pasajero_id` FOREIGN KEY (`pasajero_id`) REFERENCES `clientes` (`id`) ON DELETE CASCADE,
        CONSTRAINT `fk_boletos_destinos_destino_id` FOREIGN KEY (`destino_id`) REFERENCES `destinos` (`id`) ON DELETE CASCADE,
        CONSTRAINT `fk_boletos_destinos_origen_id` FOREIGN KEY (`origen_id`) REFERENCES `destinos` (`id`) ON DELETE CASCADE,
        CONSTRAINT `fk_boletos_pagos_pago_id` FOREIGN KEY (`pago_id`) REFERENCES `pagos` (`id`),
        CONSTRAINT `fk_boletos_usuarios_vendedor_id` FOREIGN KEY (`vendedor_id`) REFERENCES `usuarios` (`id`),
        CONSTRAINT `fk_boletos_viajes_recorrido_id` FOREIGN KEY (`recorrido_id`) REFERENCES `viajes` (`id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `celdas` (
        `id` int NOT NULL AUTO_INCREMENT,
        `value` int NOT NULL,
        `fecha_registro` datetime(6) NOT NULL,
        `fila_id` int NULL,
        CONSTRAINT `pk_celdas` PRIMARY KEY (`id`),
        CONSTRAINT `fk_celdas_filas_fila_id` FOREIGN KEY (`fila_id`) REFERENCES `filas` (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE TABLE `horarios` (
        `id` int NOT NULL AUTO_INCREMENT,
        `hora` longtext CHARACTER SET utf8mb4 NULL,
        `distribucion_id` int NULL,
        `frecuencia_id` int NULL,
        `viaje_id` int NULL,
        CONSTRAINT `pk_horarios` PRIMARY KEY (`id`),
        CONSTRAINT `fk_horarios_distribuciones_distribucion_id` FOREIGN KEY (`distribucion_id`) REFERENCES `distribuciones` (`id`),
        CONSTRAINT `fk_horarios_filas_frecuencia_id` FOREIGN KEY (`frecuencia_id`) REFERENCES `filas` (`id`),
        CONSTRAINT `fk_horarios_viajes_viaje_id` FOREIGN KEY (`viaje_id`) REFERENCES `viajes` (`id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_arista_destino_id` ON `Arista` (`destino_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_arista_origen_id` ON `Arista` (`origen_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_arista_viaje_id` ON `Arista` (`viaje_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_asp_net_role_claims_role_id` ON `AspNetRoleClaims` (`role_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`normalized_name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_asp_net_user_claims_user_id` ON `AspNetUserClaims` (`user_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_asp_net_user_logins_user_id` ON `AspNetUserLogins` (`user_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_asp_net_user_roles_role_id` ON `AspNetUserRoles` (`role_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `EmailIndex` ON `AspNetUsers` (`normalized_email`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`normalized_user_name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_boletos_destino_id` ON `boletos` (`destino_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_boletos_origen_id` ON `boletos` (`origen_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_boletos_pago_id` ON `boletos` (`pago_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_boletos_pasajero_id` ON `boletos` (`pasajero_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_boletos_recorrido_id` ON `boletos` (`recorrido_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_boletos_vendedor_id` ON `boletos` (`vendedor_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_celdas_fila_id` ON `celdas` (`fila_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_filas_distribucion_id` ON `filas` (`distribucion_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_filas_distribucion_id1` ON `filas` (`distribucion_id1`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_horarios_distribucion_id` ON `horarios` (`distribucion_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_horarios_frecuencia_id` ON `horarios` (`frecuencia_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    CREATE INDEX `ix_horarios_viaje_id` ON `horarios` (`viaje_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220117234542_InitialCreate') THEN

    INSERT INTO `__EFMigrationsHistory` (`migration_id`, `product_version`)
    VALUES ('20220117234542_InitialCreate', '6.0.1');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118000304_RemoveDniFromCliente') THEN

    ALTER TABLE `clientes` DROP COLUMN `dni`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118000304_RemoveDniFromCliente') THEN

    INSERT INTO `__EFMigrationsHistory` (`migration_id`, `product_version`)
    VALUES ('20220118000304_RemoveDniFromCliente', '6.0.1');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    ALTER TABLE `filas` ADD `distribucion_id2` int NULL;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    ALTER TABLE `filas` ADD `planta` int NOT NULL DEFAULT 0;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    ALTER TABLE `destinos` MODIFY COLUMN `nombre` varchar(100) CHARACTER SET utf8mb4 NULL;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    ALTER TABLE `destinos` ADD `created_at` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    ALTER TABLE `destinos` ADD `estado` int NOT NULL DEFAULT 0;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    ALTER TABLE `destinos` ADD `updated_at` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    CREATE INDEX `ix_filas_distribucion_id2` ON `filas` (`distribucion_id2`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    CREATE UNIQUE INDEX `ix_destinos_nombre` ON `destinos` (`nombre`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    ALTER TABLE `filas` ADD CONSTRAINT `fk_filas_distribuciones_distribucion_id2` FOREIGN KEY (`distribucion_id2`) REFERENCES `distribuciones` (`id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005550_DestinoEntity') THEN

    INSERT INTO `__EFMigrationsHistory` (`migration_id`, `product_version`)
    VALUES ('20220118005550_DestinoEntity', '6.0.1');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005734_RemoveduplicatedKeysDistribucion') THEN

    ALTER TABLE `filas` DROP FOREIGN KEY `fk_filas_distribuciones_distribucion_id1`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005734_RemoveduplicatedKeysDistribucion') THEN

    ALTER TABLE `filas` DROP FOREIGN KEY `fk_filas_distribuciones_distribucion_id2`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005734_RemoveduplicatedKeysDistribucion') THEN

    ALTER TABLE `filas` DROP INDEX `ix_filas_distribucion_id1`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005734_RemoveduplicatedKeysDistribucion') THEN

    ALTER TABLE `filas` DROP INDEX `ix_filas_distribucion_id2`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005734_RemoveduplicatedKeysDistribucion') THEN

    ALTER TABLE `filas` DROP COLUMN `distribucion_id1`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005734_RemoveduplicatedKeysDistribucion') THEN

    ALTER TABLE `filas` DROP COLUMN `distribucion_id2`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `migration_id` = '20220118005734_RemoveduplicatedKeysDistribucion') THEN

    INSERT INTO `__EFMigrationsHistory` (`migration_id`, `product_version`)
    VALUES ('20220118005734_RemoveduplicatedKeysDistribucion', '6.0.1');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;



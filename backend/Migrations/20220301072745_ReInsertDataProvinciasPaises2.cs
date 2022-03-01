using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class ReInsertDataProvinciasPaises2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "nombre", "sigla" },
                values: new object[,]
                {
                    { 4, "Afganistán", "AFG" },
                    { 8, "Albania", "ALB" },
                    { 10, "Antártida", "ATA" },
                    { 12, "Argel", "DZA" },
                    { 16, "Samoa Americana", "ASM" },
                    { 20, "Andorra", "AND" },
                    { 24, "Angola", "AGO" },
                    { 28, "Antigua y Barbuda", "ATG" },
                    { 31, "Azerbaiyán", "AZE" },
                    { 32, "Argentina", "ARG" },
                    { 36, "Australia", "AUS" },
                    { 40, "Austria", "AUT" },
                    { 44, "Bahamas", "BHS" },
                    { 48, "Bahréin", "BHR" },
                    { 50, "Bangladesh", "BGD" },
                    { 51, "Armenia", "ARM" },
                    { 52, "Barbados", "BRB" },
                    { 56, "Bélgica", "BEL" },
                    { 60, "Bermudas", "BMU" },
                    { 64, "Bhután", "BTN" },
                    { 68, "Bolivia", "BOL" },
                    { 70, "Bosnia y Herzegovina", "BIH" },
                    { 72, "Botsuana", "BWA" },
                    { 74, "Isla Bouvet", "BVT" },
                    { 76, "Brasil", "BRA" },
                    { 84, "Belice", "BLZ" },
                    { 86, "Territorio Británico del Océano Índico", "IOT" },
                    { 90, "Islas Solomón", "SLB" },
                    { 92, "Islas Vírgenes Británicas", "VGB" },
                    { 96, "Brunéi", "BRN" },
                    { 100, "Bulgaria", "BGR" },
                    { 104, "Myanmar", "MMR" },
                    { 108, "Burundi", "BDI" },
                    { 112, "Belarús", "BLR" },
                    { 116, "Camboya", "KHM" },
                    { 120, "Camerún", "CMR" },
                    { 124, "Canadá", "CAN" },
                    { 132, "Cabo Verde", "CPV" },
                    { 136, "Islas Caimán", "CYM" },
                    { 140, "República Centro-Africana", "CAF" },
                    { 144, "Sri Lanka", "LKA" },
                    { 148, "Chad", "TCD" }
                });

            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "nombre", "sigla" },
                values: new object[,]
                {
                    { 152, "Chile", "CHL" },
                    { 156, "China", "CHN" },
                    { 158, "Taiwán", "TWN" },
                    { 162, "Islas Christmas", "CXR" },
                    { 166, "Islas Cocos", "CCK" },
                    { 170, "Colombia", "COL" },
                    { 174, "Comoros", "COM" },
                    { 175, "Mayotte", "MYT" },
                    { 178, "Congo", "COG" },
                    { 184, "Islas Cook", "COK" },
                    { 188, "Costa Rica", "CRI" },
                    { 191, "Croacia", "HRV" },
                    { 192, "Cuba", "CUB" },
                    { 196, "Chipre", "CYP" },
                    { 203, "República Checa", "CZE" },
                    { 204, "Benin", "BEN" },
                    { 208, "Dinamarca", "DNK" },
                    { 212, "Domínica", "DMA" },
                    { 214, "República Dominicana", "DOM" },
                    { 218, "Ecuador", "ECU" },
                    { 222, "El Salvador", "SLV" },
                    { 226, "Guinea Ecuatorial", "GNQ" },
                    { 231, "Etiopía", "ETH" },
                    { 232, "Eritrea", "ERI" },
                    { 233, "Estonia", "EST" },
                    { 234, "Islas Faroe", "FRO" },
                    { 238, "Islas Malvinas", "KLK" },
                    { 239, "Georgia del Sur e Islas Sandwich del Sur", "SGS" },
                    { 242, "Fiji", "FJI" },
                    { 246, "Finlandia", "FIN" },
                    { 248, "Islas Áland", "ALA" },
                    { 250, "Francia", "FRA" },
                    { 254, "Guayana Francesa", "GUF" },
                    { 258, "Polinesia Francesa", "PYF" },
                    { 260, "Territorios Australes Franceses", "ATF" },
                    { 262, "Yibuti", "DJI" },
                    { 266, "Gabón", "GAB" },
                    { 268, "Georgia", "GEO" },
                    { 270, "Gambia", "GMB" },
                    { 275, "Palestina", "PSE" },
                    { 276, "Alemania", "DEU" },
                    { 288, "Ghana", "GHA" }
                });

            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "nombre", "sigla" },
                values: new object[,]
                {
                    { 292, "Gibraltar", "GIB" },
                    { 296, "Kiribati", "KIR" },
                    { 300, "Grecia", "GRC" },
                    { 304, "Groenlandia", "GRL" },
                    { 308, "Granada", "GRD" },
                    { 312, "Guadalupe", "GLP" },
                    { 316, "Guam", "GUM" },
                    { 320, "Guatemala", "GTM" },
                    { 324, "Guinea", "GIN" },
                    { 328, "Guayana", "GUY" },
                    { 332, "Haití", "HTI" },
                    { 334, "Islas Heard y McDonald", "HMD" },
                    { 336, "Ciudad del Vaticano", "VAT" },
                    { 340, "Honduras", "HND" },
                    { 344, "Hong Kong", "HKG" },
                    { 348, "Hungría", "HUN" },
                    { 352, "Islandia", "ISL" },
                    { 356, "India", "IND" },
                    { 360, "Indonesia", "IDN" },
                    { 364, "Irán", "IRN" },
                    { 368, "Irak", "IRQ" },
                    { 372, "Irlanda", "IRL" },
                    { 376, "Israel", "ISR" },
                    { 380, "Italia", "ITA" },
                    { 384, "Costa de Marfil", "CIV" },
                    { 388, "Jamaica", "JAM" },
                    { 392, "Japón", "JPN" },
                    { 398, "Kazajstán", "KAZ" },
                    { 400, "Jordania", "JOR" },
                    { 404, "Kenia", "KEN" },
                    { 408, "Corea del Norte", "PRK" },
                    { 410, "Corea del Sur", "KOR" },
                    { 414, "Kuwait", "KWT" },
                    { 417, "Kirguistán", "KGZ" },
                    { 418, "Laos", "LAO" },
                    { 422, "Líbano", "LBN" },
                    { 426, "Lesotho", "LSO" },
                    { 428, "Letonia", "LVA" },
                    { 430, "Liberia", "LBR" },
                    { 434, "Libia", "LBY" },
                    { 438, "Liechtenstein", "LIE" },
                    { 440, "Lituania", "LTU" }
                });

            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "nombre", "sigla" },
                values: new object[,]
                {
                    { 442, "Luxemburgo", "LUX" },
                    { 446, "Macao", "MAC" },
                    { 450, "Madagascar", "MDG" },
                    { 454, "Malawi", "MWI" },
                    { 458, "Malasia", "MYS" },
                    { 462, "Maldivas", "MDV" },
                    { 466, "Mali", "MLI" },
                    { 470, "Malta", "MLT" },
                    { 474, "Martinica", "MTQ" },
                    { 478, "Mauritania", "MRT" },
                    { 480, "Mauricio", "MUS" },
                    { 484, "México", "MEX" },
                    { 492, "Mónaco", "MCO" },
                    { 496, "Mongolia", "MNG" },
                    { 498, "Moldova", "MDA" },
                    { 499, "Montenegro", "MNE" },
                    { 500, "Montserrat", "MSR" },
                    { 504, "Marruecos", "MAR" },
                    { 508, "Mozambique", "MOZ" },
                    { 512, "Omán", "OMN" },
                    { 516, "Namibia", "NAM" },
                    { 520, "Nauru", "NRU" },
                    { 524, "Nepal", "NPL" },
                    { 528, "Países Bajos", "NLD" },
                    { 530, "Antillas Neerlandesas", "ANT" },
                    { 533, "Aruba", "ABW" },
                    { 540, "Nueva Caledonia", "NCL" },
                    { 548, "Vanuatu", "VUT" },
                    { 554, "Nueva Zelanda", "NZL" },
                    { 558, "Nicaragua", "NIC" },
                    { 562, "Níger", "NER" },
                    { 566, "Nigeria", "NGA" },
                    { 570, "Niue", "NIU" },
                    { 574, "Islas Norkfolk", "NFK" },
                    { 578, "Noruega", "NOR" },
                    { 583, "Micronesia", "FSM" },
                    { 584, "Islas Marshall", "MHL" },
                    { 585, "Islas Palaos", "PLW" },
                    { 586, "Pakistán", "PAK" },
                    { 591, "Panamá", "PAN" },
                    { 598, "Papúa Nueva Guinea", "PNG" },
                    { 600, "Paraguay", "PRY" }
                });

            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "nombre", "sigla" },
                values: new object[,]
                {
                    { 604, "Perú", "PER" },
                    { 608, "Filipinas", "PHL" },
                    { 612, "Islas Pitcairn", "PCN" },
                    { 616, "Polonia", "POL" },
                    { 620, "Portugal", "PRT" },
                    { 624, "Guinea-Bissau", "GNB" },
                    { 626, "Timor-Leste", "TLS" },
                    { 630, "Puerto Rico", "PRI" },
                    { 634, "Qatar", "QAT" },
                    { 638, "Reunión", "REU" },
                    { 642, "Rumanía", "ROU" },
                    { 643, "Rusia", "RUS" },
                    { 646, "Ruanda", "RWA" },
                    { 652, "San Bartolomé", "BLM" },
                    { 654, "Santa Elena", "SHN" },
                    { 659, "San Cristóbal y Nieves", "KNA" },
                    { 660, "Anguila", "AIA" },
                    { 662, "Santa Lucía", "LCA" },
                    { 666, "San Pedro y Miquelón", "SPM" },
                    { 670, "San Vicente y las Granadinas", "VCT" },
                    { 674, "San Marino", "SMR" },
                    { 678, "Santo Tomé y Príncipe", "STP" },
                    { 682, "Arabia Saudita", "SAU" },
                    { 686, "Senegal", "SEN" },
                    { 688, "Serbia y Montenegro", "SRB" },
                    { 690, "Seychelles", "SYC" },
                    { 694, "Sierra Leona", "SLE" },
                    { 702, "Singapur", "SGP" },
                    { 703, "Eslovaquia", "SVK" },
                    { 704, "Vietnam", "VNM" },
                    { 705, "Eslovenia", "SVN" },
                    { 706, "Somalia", "SOM" },
                    { 710, "Sudáfrica", "ZAF" },
                    { 724, "España", "ESP" },
                    { 732, "Sahara Occidental", "ESH" },
                    { 736, "Sudán", "SDN" },
                    { 740, "Surinam", "SUR" },
                    { 744, "Islas Svalbard y Jan Mayen", "SJM" },
                    { 748, "Suazilandia", "SWZ" },
                    { 752, "Suecia", "SWE" },
                    { 756, "Suiza", "CHE" },
                    { 760, "Siria", "SYR" }
                });

            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "nombre", "sigla" },
                values: new object[,]
                {
                    { 762, "Tayikistán", "TJK" },
                    { 764, "Tailandia", "THA" },
                    { 768, "Togo", "TGO" },
                    { 772, "Tokelau", "TKL" },
                    { 776, "Tonga", "TON" },
                    { 780, "Trinidad y Tobago", "TTO" },
                    { 784, "Emiratos Árabes Unidos", "ARE" },
                    { 788, "Túnez", "TUN" },
                    { 792, "Turquía", "TUR" },
                    { 795, "Turkmenistán", "TKM" },
                    { 796, "Islas Turcas y Caicos", "TCA" },
                    { 798, "Tuvalu", "TUV" },
                    { 800, "Uganda", "UGA" },
                    { 804, "Ucrania", "UKR" },
                    { 807, "Macedonia", "MKD" },
                    { 818, "Egipto", "EGY" },
                    { 826, "Reino Unido", "GBR" },
                    { 831, "Guernsey", "GGY" },
                    { 832, "Jersey", "JEY" },
                    { 833, "Isla de Man", "IMN" },
                    { 834, "Tanzania", "TZA" },
                    { 840, "Estados Unidos de América", "USA" },
                    { 850, "Islas Vírgenes de los Estados Unidos de América", "VIR" },
                    { 854, "Burkina Faso", "BFA" },
                    { 858, "Uruguay", "URY" },
                    { 860, "Uzbekistán", "UZB" },
                    { 862, "Venezuela", "VEN" },
                    { 876, "Wallis y Futuna", "WLF" },
                    { 882, "Samoa", "WSM" },
                    { 887, "Yemen", "YEM" }
                });

            migrationBuilder.InsertData(
                table: "provincias",
                columns: new[] { "id", "nombre", "pais_id", "sigla" },
                values: new object[,]
                {
                    { 1, "Subdivision name", 32, "3166-2 code" },
                    { 2, "Buenos Aires", 32, "AR-B" },
                    { 3, "Catamarca", 32, "AR-K" },
                    { 4, "Chaco", 32, "AR-H" },
                    { 5, "Chubut", 32, "AR-U" },
                    { 6, "Ciudad Autónoma de Buenos Aires", 32, "AR-C" },
                    { 7, "Corrientes", 32, "AR-W" },
                    { 8, "Córdoba", 32, "AR-X" },
                    { 9, "Entre Ríos", 32, "AR-E" },
                    { 10, "Formosa", 32, "AR-P" },
                    { 11, "Jujuy", 32, "AR-Y" },
                    { 12, "La Pampa", 32, "AR-L" },
                    { 13, "La Rioja", 32, "AR-F" },
                    { 14, "Mendoza", 32, "AR-M" },
                    { 15, "Misiones", 32, "AR-N" },
                    { 16, "Neuquén", 32, "AR-Q" },
                    { 17, "Río Negro", 32, "AR-R" },
                    { 18, "Salta", 32, "AR-A" },
                    { 19, "San Juan", 32, "AR-J" },
                    { 20, "San Luis", 32, "AR-D" },
                    { 21, "Santa Cruz", 32, "AR-Z" },
                    { 22, "Santa Fe", 32, "AR-S" },
                    { 23, "Santiago del Estero", 32, "AR-G" },
                    { 24, "Tierra del Fuego", 32, "AR-V" },
                    { 25, "Tucumán", 32, "AR-T" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 724);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 732);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 736);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 740);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 833);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 834);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 850);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 854);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 858);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 860);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 862);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 876);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 882);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 887);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "paises",
                keyColumn: "id",
                keyValue: 32);
        }
    }
}

﻿namespace Nox.Types.Tests;

public class NoxCountryNumberTest
{
    [Theory]
    [InlineData(004)]
    [InlineData(008)]
    [InlineData(010)]
    [InlineData(012)]
    [InlineData(016)]
    [InlineData(020)]
    [InlineData(024)]
    [InlineData(028)]
    [InlineData(031)]
    [InlineData(032)]
    [InlineData(036)]
    [InlineData(040)]
    [InlineData(044)]
    [InlineData(048)]
    [InlineData(050)]
    [InlineData(051)]
    [InlineData(052)]
    [InlineData(056)]
    [InlineData(060)]
    [InlineData(064)]
    [InlineData(068)]
    [InlineData(070)]
    [InlineData(072)]
    [InlineData(074)]
    [InlineData(076)]
    [InlineData(084)]
    [InlineData(086)]
    [InlineData(090)]
    [InlineData(092)]
    [InlineData(096)]
    [InlineData(100)]
    [InlineData(104)]
    [InlineData(108)]
    [InlineData(112)]
    [InlineData(116)]
    [InlineData(120)]
    [InlineData(124)]
    [InlineData(132)]
    [InlineData(136)]
    [InlineData(140)]
    [InlineData(144)]
    [InlineData(148)]
    [InlineData(152)]
    [InlineData(156)]
    [InlineData(158)]
    [InlineData(162)]
    [InlineData(166)]
    [InlineData(170)]
    [InlineData(174)]
    [InlineData(175)]
    [InlineData(178)]
    [InlineData(180)]
    [InlineData(184)]
    [InlineData(188)]
    [InlineData(191)]
    [InlineData(192)]
    [InlineData(196)]
    [InlineData(203)]
    [InlineData(204)]
    [InlineData(208)]
    [InlineData(212)]
    [InlineData(214)]
    [InlineData(218)]
    [InlineData(222)]
    [InlineData(226)]
    [InlineData(231)]
    [InlineData(232)]
    [InlineData(233)]
    [InlineData(234)]
    [InlineData(238)]
    [InlineData(239)]
    [InlineData(242)]
    [InlineData(246)]
    [InlineData(248)]
    [InlineData(250)]
    [InlineData(254)]
    [InlineData(258)]
    [InlineData(260)]
    [InlineData(262)]
    [InlineData(266)]
    [InlineData(268)]
    [InlineData(270)]
    [InlineData(275)]
    [InlineData(276)]
    [InlineData(288)]
    [InlineData(292)]
    [InlineData(296)]
    [InlineData(300)]
    [InlineData(304)]
    [InlineData(308)]
    [InlineData(312)]
    [InlineData(316)]
    [InlineData(320)]
    [InlineData(324)]
    [InlineData(328)]
    [InlineData(332)]
    [InlineData(334)]
    [InlineData(336)]
    [InlineData(340)]
    [InlineData(344)]
    [InlineData(348)]
    [InlineData(352)]
    [InlineData(356)]
    [InlineData(360)]
    [InlineData(364)]
    [InlineData(368)]
    [InlineData(372)]
    [InlineData(376)]
    [InlineData(380)]
    [InlineData(384)]
    [InlineData(388)]
    [InlineData(392)]
    [InlineData(398)]
    [InlineData(400)]
    [InlineData(404)]
    [InlineData(408)]
    [InlineData(410)]
    [InlineData(414)]
    [InlineData(417)]
    [InlineData(418)]
    [InlineData(422)]
    [InlineData(426)]
    [InlineData(428)]
    [InlineData(430)]
    [InlineData(434)]
    [InlineData(438)]
    [InlineData(440)]
    [InlineData(442)]
    [InlineData(446)]
    [InlineData(450)]
    [InlineData(454)]
    [InlineData(458)]
    [InlineData(462)]
    [InlineData(466)]
    [InlineData(470)]
    [InlineData(474)]
    [InlineData(478)]
    [InlineData(480)]
    [InlineData(484)]
    [InlineData(492)]
    [InlineData(496)]
    [InlineData(498)]
    [InlineData(499)]
    [InlineData(500)]
    [InlineData(504)]
    [InlineData(508)]
    [InlineData(512)]
    [InlineData(516)]
    [InlineData(520)]
    [InlineData(524)]
    [InlineData(528)]
    [InlineData(531)]
    [InlineData(533)]
    [InlineData(534)]
    [InlineData(535)]
    [InlineData(540)]
    [InlineData(548)]
    [InlineData(554)]
    [InlineData(558)]
    [InlineData(562)]
    [InlineData(566)]
    [InlineData(570)]
    [InlineData(574)]
    [InlineData(578)]
    [InlineData(580)]
    [InlineData(581)]
    [InlineData(583)]
    [InlineData(584)]
    [InlineData(585)]
    [InlineData(586)]
    [InlineData(591)]
    [InlineData(598)]
    [InlineData(600)]
    [InlineData(604)]
    [InlineData(608)]
    [InlineData(612)]
    [InlineData(616)]
    [InlineData(620)]
    [InlineData(624)]
    [InlineData(626)]
    [InlineData(630)]
    [InlineData(634)]
    [InlineData(638)]
    [InlineData(642)]
    [InlineData(643)]
    [InlineData(646)]
    [InlineData(652)]
    [InlineData(654)]
    [InlineData(659)]
    [InlineData(660)]
    [InlineData(662)]
    [InlineData(663)]
    [InlineData(666)]
    [InlineData(670)]
    [InlineData(674)]
    [InlineData(678)]
    [InlineData(682)]
    [InlineData(686)]
    [InlineData(688)]
    [InlineData(690)]
    [InlineData(694)]
    [InlineData(702)]
    [InlineData(703)]
    [InlineData(704)]
    [InlineData(705)]
    [InlineData(706)]
    [InlineData(710)]
    [InlineData(716)]
    [InlineData(724)]
    [InlineData(728)]
    [InlineData(729)]
    [InlineData(732)]
    [InlineData(740)]
    [InlineData(744)]
    [InlineData(748)]
    [InlineData(752)]
    [InlineData(756)]
    [InlineData(760)]
    [InlineData(762)]
    [InlineData(764)]
    [InlineData(768)]
    [InlineData(772)]
    [InlineData(776)]
    [InlineData(780)]
    [InlineData(784)]
    [InlineData(788)]
    [InlineData(792)]
    [InlineData(795)]
    [InlineData(796)]
    [InlineData(798)]
    [InlineData(800)]
    [InlineData(804)]
    [InlineData(807)]
    [InlineData(818)]
    [InlineData(826)]
    [InlineData(831)]
    [InlineData(832)]
    [InlineData(833)]
    [InlineData(834)]
    [InlineData(840)]
    [InlineData(850)]
    [InlineData(854)]
    [InlineData(858)]
    [InlineData(860)]
    [InlineData(862)]
    [InlineData(876)]
    [InlineData(882)]
    [InlineData(887)]
    [InlineData(894)]

    public void Nox_CountryNumber_Constructor_ReturnsSameValue(short value)
    {
        var countryNumber = CountryNumber.From(value);

        Assert.Equal(value, countryNumber.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(22)]
    [InlineData(900)]
    [InlineData(1000)]
    public void Nox_CountryNumber_Constructor_WithUnallowedValue_ThrowsException(short value)
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            CountryNumber.From(value)
        );

        Assert.Equal($"Could not create a Nox CountryNumber type as value {value} is not allowed.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void Nox_CountryNumber_Equality_Tests()
    {
        var countryNumber1 = CountryNumber.From(214);

        var countryNumber2 = CountryNumber.From(214);

        Assert.Equal(countryNumber1, countryNumber2);
    }

    [Fact]
    public void Nox_CountryNumber_NotEqual_Tests()
    {
        var countryNumber1 = CountryNumber.From(218);

        var countryNumber2 = CountryNumber.From(222);

        Assert.NotEqual(countryNumber1, countryNumber2);
    }

    [Theory]
    [InlineData(4, "004")]
    [InlineData(12, "012")]
    [InlineData(124, "124")]
    public void Nox_CountryNumber_ToString_ReturnsThreeDigitStringRepresentation(short value, string threeDigitStringRepresentation)
    {
        var countryNumber = CountryNumber.From(value);

        Assert.Equal(threeDigitStringRepresentation, countryNumber.ToString());
    }
}

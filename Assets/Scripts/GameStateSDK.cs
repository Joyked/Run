using YG;

public static class GameStateSDK
{
    public static bool HasRussianLocale() =>
        YG2.envir.language == "ru";
}

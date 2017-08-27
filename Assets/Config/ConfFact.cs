using System.Collections.Generic;

class ConfFact
{
    static bool reloadStarted = false;
    
    public static void Register()
    {
         ConfGameArticle.Init();
         Confmission.Init();
         ConfPlayerProperty.Init();
         ConfZMJS.Init();
    }
    
    public static bool ResLoaded()
    {
        if( ConfGameArticle.cacheLoaded == ConfGameArticle.resLoaded )
            return true;
        if( Confmission.cacheLoaded == Confmission.resLoaded )
            return true;
        if( ConfPlayerProperty.cacheLoaded == ConfPlayerProperty.resLoaded )
            return true;
        if( ConfZMJS.cacheLoaded == ConfZMJS.resLoaded )
            return true;
        return false;
    }
    
    public static void ReloadConfig()
    {
        ConfGameArticle.Clear();
        ConfGameArticle.Init();
        Confmission.Clear();
        Confmission.Init();
        ConfPlayerProperty.Clear();
        ConfPlayerProperty.Init();
        ConfZMJS.Clear();
        ConfZMJS.Init();
        reloadStarted = true;
    }
    
    public static bool IsReloadCompleted()
    {
        if(reloadStarted)
        {
            if(ResLoaded())
            {
                reloadStarted = false;
                return true;
            }
        }
        return false;
    }
}

using Godot;

public class Sound {
  public enum Effects{
    None,
    RifleShot,
    RifleReload,
    FistSwing,
    FistImpact,
    ActorDamage,
    ActorDeath
  };

  public enum Songs{
    None,
    FloatingHorizons
  };

  public static string SongFile(Songs song){
    string ret = "";
    switch(song){
      case Songs.FloatingHorizons: 
        ret = "res://Audio/Songs/floating_horizons.ogg"; 
        break;
    }
    return ret;
  }
  
  public static string EffectFile(Effects effect){
    string ret = "";
    switch(effect){
      case Effects.RifleShot:
        ret = "res://Audio/Effects/pew.wav";
        break;
      case Effects.RifleReload:
        ret = "res://Audio/Effects/chtcht.wav";
        break;
      case Effects.FistSwing:
        ret = "res://Audio/Effects/swing.wav";
        break;
      case Effects.FistImpact:
        ret = "res://Audio/Effects/impact.wav";
        break;
      case Effects.ActorDamage:
        ret = "res://Audio/Effects/actor_damage.wav";
        break;
      case Effects.ActorDeath:
        ret = "res://Audio/Effects/actor_die.wav";
        break;
    }
    return ret;
  }
  
  public static void PlaySong(Songs song){
    if(song == Songs.None){
      return;
    }
    
    string fileName = SongFile(song);
    AudioStreamOGGVorbis stream = (AudioStreamOGGVorbis)GD.Load(fileName);
    if(Session.session.jukeBox == null){
      Session.session.InitJukeBox();
    }
    Session.session.jukeBox.Stream = stream;
    Session.session.jukeBox.Playing = true;
  }
  
  public static void PauseSong(){
    if(Session.session.jukeBox == null){
      return;
    }
    Session.session.jukeBox.Playing = false;
  }
}
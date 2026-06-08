namespace RoboterDatenverwaltung;

public interface ISerializer
{
    void SpeichernGeneric(string dateipfad);
    static abstract Roboter Laden(string dateipfad);

}
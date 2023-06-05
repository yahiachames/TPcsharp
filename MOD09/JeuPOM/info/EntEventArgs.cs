namespace info
{
    public class EntEventArgs : EventArgs
    {
        public string posteRestant;
        public EntEventArgs(int nbPosteRestant)
        : base()
        {
            this.posteRestant = "Il reste " + nbPosteRestant +
           " poste(s) de libre.";
        }
    }

}
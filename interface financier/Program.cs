// L'interface définissant un instrument financier.
public interface IInstrumentFinancier
{
    void Investir(decimal montant);
    bool Retirer(decimal montant);
    decimal Evaluer();
}

// La classe représentant des actions.
public class Actions : IInstrumentFinancier
{
    public decimal PrixParAction { get; private set; }
    public int NombreActions { get; private set; }

    public Actions(decimal prixParAction)
    {
        PrixParAction = prixParAction;
        NombreActions = 0;
    }

    public void Investir(decimal montant)
    {
        int actionsAchetees = (int)(montant / PrixParAction);
        NombreActions += actionsAchetees;
    }

    public bool Retirer(decimal montant)
    {
        int actionsVendues = (int)(montant / PrixParAction);
        if (actionsVendues <= NombreActions)
        {
            NombreActions -= actionsVendues;
            return true;
        }
        return false;  // Pas suffisamment d'actions pour vendre
    }

    public decimal Evaluer()
    {
        return NombreActions * PrixParAction;
    }

    public void Fluctuer(decimal pourcentage)
    {
        PrixParAction *= (1 + pourcentage / 100);
    }
}

// La classe représentant des obligations.
public class Obligations : IInstrumentFinancier
{
    public decimal TauxInteret { get; private set; }
    public decimal Principal { get; private set; }

    public Obligations(decimal tauxInteret, decimal principal)
    {
        TauxInteret = tauxInteret;
        Principal = principal;
    }

    public void Investir(decimal montant)
    {
        Principal += montant;
    }

    public bool Retirer(decimal montant)
    {
        if (montant <= Principal)
        {
            Principal -= montant;
            return true;
        }
        return false;  // Pas suffisamment d'argent pour retirer
    }

    public decimal Evaluer()
    {
        return Principal;
    }

    public void Mature()
    {
        Principal += Principal * TauxInteret / 100;
    }
}

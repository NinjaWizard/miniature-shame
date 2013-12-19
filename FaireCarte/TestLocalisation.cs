using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FaireCarte
{
    class TestLocalisation
    {
        public static List<String> creerBonsSSIDs()
        {
            var ssids = "a4:56:30:46:12:84;a4:56:30:46:12:83;a4:56:30:46:12:82;a4:56:30:01:7f:0b;a4:56:30:46:0a:d4;a4:56:30:46:0c:74;a4:56:30:01:7f:03;a4:56:30:01:7f:0d;a4:56:30:01:7f:0c;a4:56:30:46:0a:dc;a4:56:30:46:0c:72;a4:56:30:01:7f:02;a4:56:30:46:0a:d3;a4:56:30:46:0a:d2;a4:56:30:01:7f:04;a4:56:30:46:11:24;a4:56:30:46:0a:db;a4:56:30:46:0a:dd;a4:56:30:46:0c:73".Split(';').ToList();
            
            return ssids;
        }

        public static List<String> creerBonsSSIDs2()
        {
            var ssids = "a4:56:30:46:03:33;d4:a0:2a:14:7f:42;a4:56:30:15:51:c2;d4:a0:2a:99:59:c3;d4:a0:2a:99:59:cd;d4:a0:2a:4b:fb:a2;d4:a0:2a:4b:fd:63;d4:a0:2a:10:21:14;d4:a0:2a:4b:fb:a4;d4:a0:2a:99:59:cb;d4:a0:2a:99:59:c4;d4:a0:2a:4b:fd:64;d4:a0:2a:4b:fb:a3;d4:a0:2a:99:59:cc;d4:a0:2a:99:59:c2;d4:a0:2a:4b:fd:62;00:1d:7e:68:8a:a1;a4:56:30:15:29:84;a4:56:30:15:29:83;a4:56:30:15:29:82;a4:56:30:15:29:8b;d4:a0:2a:10:21:1b;a4:56:30:46:11:1b;a4:56:30:46:11:14;a4:56:30:15:37:c4;a4:56:30:15:29:8d;a4:56:30:15:29:8c;d4:a0:2a:10:21:1d;d4:a0:2a:10:21:1c;a4:56:30:46:11:1d;a4:56:30:46:11:1c;a4:56:30:46:11:13;a4:56:30:46:11:12;a4:56:30:15:37:c3;a4:56:30:15:37:c2;c8:be:19:71:c1:10;58:6d:8f:09:65:8f;c8:be:19:71:bf:0a;d4:a0:2a:10:21:12;d4:a0:2a:10:21:13;a4:56:30:15:58:03;58:6d:8f:09:65:90;a4:56:30:15:5e:b2;a4:56:30:15:5e:b3".Split(';').ToList();
            
            return ssids;
        }
        

        public static List<String> creerSSIDsPartiels()
        {
            var ssids = "a4:56:30:4612:84;a4:56:30:46:12:83;a4:56:30:46:12:82".Split(';').ToList();

            return ssids;
        }

        public static List<String> creerSSIDsDeDeuxFeatures()
        {
            var ssids = "d4:a0:2a:9a:00:94;a4:56:30:15:54:14;d4:a0:2a:9a:00:93;d4:a0:2a:9a:00:92;a4:56:30:15:54:13;a4:56:30:46:03:33;a4:56:30:15:54:12;d4:a0:2a:10:21:14;d4:a0:2a:4b:fb:a4;d4:a0:2a:99:59:cb;d4:a0:2a:99:59:c4;d4:a0:2a:4b:fd:64;d4:a0:2a:4b:fb:a3;d4:a0:2a:99:59:cc;d4:a0:2a:99:59:c2;d4:a0:2a:4b:fd:62;00:1d:7e:68:8a:a1;a4:56:30:15:29:84;a4:56:30:15:29:83;a4:56:30:15:29:82;a4:56:30:15:29:8b;d4:a0:2a:10:21:1b;a4:56:30:46:11:1b;a4:56:30:46:11:14;a4:56:30:15:37:c4;a4:56:30:15:29:8d;a4:56:30:15:29:8c;d4:a0:2a:10:21:1d;d4:a0:2a:10:21:1c;a4:56:30:46:11:1d;a4:56:30:46:11:1c;a4:56:30:46:11:13;a4:56:30:46:11:12;a4:56:30:15:37:c3;a4:56:30:15:37:c2;c8:be:19:71:c1:10;58:6d:8f:09:65:8f;c8:be:19:71:bf:0a;d4:a0:2a:10:21:12;d4:a0:2a:10:21:13;a4:56:30:15:58:03;58:6d:8f:09:65:90;a4:56:30:15:5e:b2;a4:56:30:15:5e:b3".Split(';').Distinct().ToList();

            return ssids;
        }

        public static List<String> creerSSIDsInconnus()
        {
            var ssids = "00:00:01:01:05:ff".Split(';').Distinct().ToList();

            return ssids;
        }

        public static List<String> creerAucunSSID()
        {
            var ssids = "".Split(';').Distinct().ToList();

            return ssids;
        }

        public void creerBonSSIDsDevraitMatcherUnPointParticulier(List<Noeud> pings){
            var localizer = new Localizer();
            var currentScan = creerBonsSSIDs();
            List<Noeud> normalizedMatches = localizer.findBestMatch(currentScan, pings);
        }

    }
}
